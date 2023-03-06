using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain.Base;

namespace TSReimbursementApp.DAL.Domain
{
    public class ReimbursementDomain:DomainBase
    {
        public ReimbursementDomain()
        {
            IsApproved = false;
        }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please enter date.")]
        public DateTime Date { get; set; }

        [Display(Name = "Reimbursement Type")]
        [Required(ErrorMessage = "Please choose Reimbursement type.")]
        public string ReimbursementType { get; set; }

        [Display(Name = "Requested Value")]
        [Required(ErrorMessage = "Please enter Requested value.")]
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
