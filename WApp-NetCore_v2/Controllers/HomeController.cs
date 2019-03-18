using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WApp_NetCore_v2.Models;

namespace WApp_NetCore_v2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly UserManager<IdentityUser> _userManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HomeController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            if (User.Identity.IsAuthenticated)
            {
                var verifi = await _roleManager.FindByNameAsync("Administrador");
                if (verifi != null)
                {

                }
                else
                {
                    var res = await _roleManager.CreateAsync(new IdentityRole("Administrador"));
                    if (res.Succeeded)
                    {
                        var user = await _userManager.GetUserAsync(HttpContext.User);
                        await _userManager.AddToRoleAsync(user, "Administrador");
                    }
                }
            }

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
