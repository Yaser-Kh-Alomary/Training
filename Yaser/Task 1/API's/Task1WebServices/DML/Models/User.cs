
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DML.Models
{
    public class User
    {
        public string UserID { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        public int RoleID { get; set; }

        public int StatusID { get; set; }

        public IFormFile File { get; set; }


    }
}
