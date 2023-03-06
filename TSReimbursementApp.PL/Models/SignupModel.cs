using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TSReimbursementApp.PL.Models.Base;

namespace TSReimbursementApp.PL.Models
{
    public class SignupModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter email.")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter Password.")]
        public string Password { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter Full Name.")]
        public string FullName { get; set; }

        [Display(Name = "PAN number")]
        [Required(ErrorMessage = "Please enter PAN Number.")]
        public int PANNumber { get; set; }

        [Display(Name = "Bank")]
        [Required(ErrorMessage = "Please enter Bank.")]
        public string Bank { get; set; }

        [Display(Name = "Bank Account Number")]
        [Required(ErrorMessage = "Please enter Bank Account Number.")]
        public int BankAccNumber { get; set; }
    }
}
