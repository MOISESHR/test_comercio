using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WApp_NetCore_v2.Models;

namespace WApp_NetCore_v2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // builder.Entity<User>(entity => { entity.ToTable(name: "User"); });
            // builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Role"); });
            // builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            // builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            // builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            // builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserToken"); });
            // builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaim"); });

            
            // builder.Entity<UserProfile>().ToTable("UserProfile");
            // builder.Entity<UserProfile>().Property(up => up.Id).HasColumnName("UserId");
            // builder.Entity<UserRole>().ToTable("Role").Property(ur => ur.Id).HasColumnName("RoleId");
            // builder.Entity<UserRole>().Property(ur => ur.Id).HasColumnName("UserRoleId");
            // builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            // builder.Entity<IdentityUserRole<int>>().ToTable("UserRole").HasKey(k => new {k.RoleId, k.UserId});
            // builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            // builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            // builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");

        }
    }
}
