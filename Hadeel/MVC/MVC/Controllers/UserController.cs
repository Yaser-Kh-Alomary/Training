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


    public class UserController : Controller
    {

        private readonly UserManager<AppUser> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;



        public UserController(UserManager<AppUser> userManager , RoleManager<IdentityRole> roleManager)
        {
            _UserManager = userManager;
            _RoleManager = roleManager;


        }

    
         public async Task<IActionResult> Index()
        {
           
            var users = await _UserManager.Users.Select(user => new UserViewModels {

                Id = user.Id,
                FirstName = user.F_Name,
                LastName = user.L_Name,
                UserName = user.UserName,
                Email = user.Email , 
                Role = _UserManager.GetRolesAsync(user).Result}).ToListAsync();


                   return View(users);
        }
      
    
    }
}
