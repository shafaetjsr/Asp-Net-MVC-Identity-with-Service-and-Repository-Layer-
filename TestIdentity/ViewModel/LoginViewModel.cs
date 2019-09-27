using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestIdentity.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="User Name Can't be Null")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Can't be Null")]
        public string Password { get; set; }
    }
}