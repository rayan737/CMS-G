﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSG.Models
{
    public class RegistrationVM
    {
        [Required(ErrorMessage = "Mail Required")]
        [EmailAddress(ErrorMessage = "You Must Enter Valid Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [MinLength(3, ErrorMessage = "Min Len 3")]
        [Compare("Password", ErrorMessage = "Not Matching")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
