using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ASP.Models.ViewModels
{
    public class RegistationViewModel
    {
        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name ="Password Confirm")]
        public string PasswordConfirm { get; set; }



    }
}
