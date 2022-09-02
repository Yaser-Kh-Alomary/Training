using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class UserRolesViewModel
    {

        public string UserID { get; set; }
        public string UserName { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }
}
