using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class UserViewModels
    {

        public string Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }


        public IEnumerable<string> Role { get; set; }

    }
}
