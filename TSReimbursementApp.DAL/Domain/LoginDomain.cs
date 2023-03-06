using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSReimbursementApp.DAL.Domain
{
    public class LoginDomain
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter Email.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; }
    }
}
