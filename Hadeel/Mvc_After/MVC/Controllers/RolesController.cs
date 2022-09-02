using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{

    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> Role_Manager;


        public RolesController(RoleManager<IdentityRole> role_Manager ) {
            Role_Manager = role_Manager;
        }



        public async Task <IActionResult> Index()
        {
            var roles = await Role_Manager.Roles.ToListAsync();
            return View(roles);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(RoleFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index" , await Role_Manager.Roles.ToListAsync());


            if (await Role_Manager.RoleExistsAsync(model.Name)) 
            {

                ModelState.AddModelError("Name" , "Role Is Exists");
                return View("Index", await Role_Manager.Roles.ToListAsync());

            }
            await Role_Manager.CreateAsync(new IdentityRole(model.Name.Trim()));
            return RedirectToAction(nameof(Index));
        }
    }
}
