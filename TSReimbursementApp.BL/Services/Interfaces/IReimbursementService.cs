using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.DTOs;

namespace TSReimbursementApp.BL.Services.Interfaces
{
    public interface IReimbursementService
    {
        public Task<ReimbursementDTO> GetReimbursement(int id);
        public Task<IList<ReimbursementDTO>> GetAllReimbursements();
        public Task<IList<ReimbursementDTO>> GetReimbursementByEmail(string email);

        public Task<ReimbursementDTO> AddReimbursement(ReimbursementDTO reimbursement);

        public Task<ReimbursementDTO> DeleteReimbursement(int id);

        public Task<ReimbursementDTO> UpdateReimbursement(int id, ReimbursementDTO reimbursement);

    }
}
