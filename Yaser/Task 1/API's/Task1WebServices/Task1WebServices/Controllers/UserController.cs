using DAL.AccessPoints;
using DML.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1WebServices.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class UserController : ControllerBase
    {

        User_Context context;
        public UserController(User_Context context)
        {
            this.context = context;
        }

        [HttpPost("~/AddUser")]
        public Task<bool> AddUser([FromForm] User user)
        {
            return this.context.AddUsers(user);
        }
        [HttpGet("~/GetUserByIDAsync")]
        public Task<List<User>> GetUserByIDAsync(string id) {
            return this.GetUserByIDAsync(id);
        }
    }
}
