using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.DTOs.Base;

namespace TSReimbursementApp.DAL.DTOs
{
    public class SignupDTO
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int PANNumber { get; set; }
        public string Bank { get; set; }
        public int BankAccNumber { get; set; }
    }
}
