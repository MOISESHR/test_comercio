using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WApp_NetCore_v2.Data;
using WApp_NetCore_v2.Models;
using WApp_NetCore_v2.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WApp_NetCore_v2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionSeguridad")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Lockout.MaxFailedAccessAttempts = 6;

                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 3;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);		//TIEMPO DURACION 5 minutos
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    options.User.RequireUniqueEmail = true;

            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "AppCookieMHR";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromSeconds(300);
                options.LoginPath = "/Account/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            //Base de datos DB_MHR_Comercio
            services.AddDbContext<ComercioDbContext>(options =>             
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionComercio")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
