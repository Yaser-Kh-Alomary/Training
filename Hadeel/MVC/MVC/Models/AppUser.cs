﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class AppUser : IdentityUser

    {


        [Required , Maxlength(100)]
        public string F_Name { get; set; }

        [Required, Maxlength(100)]
        public string L_Name { get; set; }

        public byte[] profile_Pic { get; set; }



    }
}
