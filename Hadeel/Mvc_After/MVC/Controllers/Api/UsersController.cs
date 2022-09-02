using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers.Api
{


    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;


        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            if (user == null)
                return NotFound();

            var Result = await _userManager.DeleteAsync(user);
            if (!Result.Succeeded)
                 throw new Exception();

          
            return Ok();
        }
    }
}
