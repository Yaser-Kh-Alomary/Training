using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;
using MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{

    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UsersController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }



        public async Task<IActionResult> Index()
        {
            var Users = await _userManager.Users.Select(
                user => new UsersViewModels
                {

                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = _userManager.GetRolesAsync(user).Result
                }).ToListAsync();
            return View(Users);
        }




        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.Select(r => new RoleViewModel
            {
                RoleID = r.Id,
                RoleName = r.Name

            }).ToListAsync();

            var ViewModel = new AddUserViewModel
            {
                Roles = roles
            };

            return View(ViewModel);


        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);



            if (!model.Roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("Roles", "Pleas Select at least one role ");
                return View(model);
            }

            if (await _userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "Email is already exists");
                return View(model);
            }

            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("UserName", "User Name is already exists");
                return View(model);
            }

            var user = new AppUser

            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.F_Name,
                LastName = model.L_Name
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Roles ", error.Description);
                }
                return View(model);
            }



            await _userManager.AddToRolesAsync(user, model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName));


            return RedirectToAction(nameof(Index));

        }






        public async Task<IActionResult> Edit(string userId)

        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();


            var ViewModel = new ProfileFormViewModel
            {
                Id = user.Id,
                F_Name = user.FirstName,
                L_Name = user.LastName,
                UserName = user.UserName,
                Email = user.Email

            };
            return View(ViewModel);

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileFormViewModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.FindByIdAsync(model.Id);

            if (user == null)
                return NotFound();



            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            if (userWithSameEmail != null && userWithSameEmail.Id != model.Id)
            {
                ModelState.AddModelError("Email", "Tis Email is already assign to another users");
                return View(model);
            }


            var userWithSameUserName = await _userManager.FindByNameAsync(model.UserName);
            if (userWithSameUserName != null && userWithSameUserName.UserName != model.UserName)
            {
                ModelState.AddModelError("Username", "Tis UserName is already assign to another users");
                return View(model);
            }


            user.FirstName = model.F_Name;
            user.LastName = model.L_Name;
            user.UserName = model.UserName;
            user.Email = model.Email;



            await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(Index));

        }


























        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound();

            var roles = await _roleManager.Roles.ToListAsync();

            var ViewModel = new UserRolesViewModel
            {
                UserID = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel
                {
                    RoleID = role.Id,
                    RoleName = role.Name,
                    IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
                }
                ).ToList()

            };
            return View(ViewModel);


        }














        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserID);

            if (user == null)
                return NotFound();


            var userRoles = await _userManager.GetRolesAsync(user);


            foreach (var role in model.Roles)
            {

                if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);


                if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                    await _userManager.AddToRoleAsync(user, role.RoleName);


            }

            return RedirectToAction(nameof(Index));

        }


    }
}
