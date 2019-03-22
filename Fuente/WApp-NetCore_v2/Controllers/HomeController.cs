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
                string NombreRol = "Administrador";

                var verifi = await _roleManager.FindByNameAsync(NombreRol);
                if (verifi != null)
                {

                }
                else
                {
                    var res = await _roleManager.CreateAsync(new IdentityRole(NombreRol));
                    if (res.Succeeded)
                    {
                        var user = await _userManager.GetUserAsync(HttpContext.User);
                        await _userManager.AddToRoleAsync(user, NombreRol);
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
