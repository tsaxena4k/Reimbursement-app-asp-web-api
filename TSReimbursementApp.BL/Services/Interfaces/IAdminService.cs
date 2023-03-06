using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.DTOs;

namespace TSReimbursementApp.BL.Services.Interfaces
{
    public interface IAdminService
    {
        public Task<ReimbursementDTO> ApproveReimbursement(int id, ReimbursementDTO reimbursement);
        public Task<ReimbursementDTO> DeclineReimbursement(int id);

    }
}
