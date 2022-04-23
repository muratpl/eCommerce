using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.UI.Models
{
    public class Login
    {
        [Required]
        [Display(Name ="Username")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me!")]
        public bool RememberMe { get; set; }
    }
}