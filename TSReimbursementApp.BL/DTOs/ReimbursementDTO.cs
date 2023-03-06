using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.DTOs.Base;

namespace TSReimbursementApp.DAL.DTOs
{
    public class ReimbursementDTO:DtoBase
    {
        public ReimbursementDTO()
        {
            IsApproved = false;
        }
        public DateTime Date { get; set; }
        public string ReimbursementType { get; set; }
        public double RequestedValue { get; set; }
        public string Currency { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public Boolean IsApproved { get; set; }
        public double ApprovedValue { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovedBy { get; set; }
        public string InternalNotes { get; set; }
    }
}
