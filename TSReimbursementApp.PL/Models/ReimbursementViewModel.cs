using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TSReimbursementApp.PL.Models.Base;

namespace TSReimbursementApp.PL.Models
{
    public class ReimbursementViewModel:ViewModel
    {

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please enter date.")]
        public DateTime Date { get; set; }

        [Display(Name = "Reimbursement Type")]
        [Required(ErrorMessage = "Please choose Reimbursement type.")]
        public string ReimbursementType { get; set; }

        [Display(Name = "Requested Value")]
        [Required(ErrorMessage = "Please enter Requested value.")]
        [RegularExpression(@"^\-?[0-9]+(?:\.[0-9]{1,2})?$",ErrorMessage ="Requested value should be of atmost 2 decimals")]
        public double RequestedValue { get; set; }

        [Display(Name = "Currency")]
        [Required(ErrorMessage = "Please choose currency.")]
        public string Currency { get; set; }

        [Display(Name = "File")]
        public string Image { get; set; }

        public string UserId { get; set; }

        public Boolean IsApproved { get; set; }

        public double ApprovedValue { get; set; }

        public string ApprovalStatus { get; set; }

        public string ApprovedBy { get; set; }

        public string InternalNotes { get; set; }
    }
}
