using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSReimbursementApp.DAL.Domain
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Please enter Full Name.")]
        public string FullName { get; set; }

        [Display(Name = "PAN number")]
        [Required(ErrorMessage = "Please enter PAN Number.")]
        [MinLength(10)]
        [MaxLength(10)]
        public int PANNumber { get; set; }

        [Display(Name = "Bank")]
        [Required(ErrorMessage = "Please enter Bank.")]
        public string Bank { get; set; }

        [Display(Name = "Bank Account Number")]
        [Required(ErrorMessage = "Please enter Bank Account Number.")]
        [MinLength(12)]
        [MaxLength(12)]
        public long BankAccNumber { get; set; }

        //public string Role { get; set; }
    }
}
