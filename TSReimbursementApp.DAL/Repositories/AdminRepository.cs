using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.DBContext;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.Repositories.IRepository;

namespace TSReimbursementApp.DAL.Repositories
{
    public class AdminRepository: IAdminRepository
    {
        private readonly ReimbursementContext _context;

        public AdminRepository(ReimbursementContext context)
        {
            this._context = context;
        }

        public async Task<ReimbursementDomain> ApproveReimbursement(int id,ReimbursementDomain reimbursement)
        {
            var reimbursementToBeUpdated = await _context.Reimbursements.FirstOrDefaultAsync(x => x.Id == id);
            if (reimbursementToBeUpdated != null)
            {
                reimbursementToBeUpdated.ApprovalStatus = "Approved";
                reimbursementToBeUpdated.ApprovedBy = reimbursement.ApprovedBy;
                reimbursementToBeUpdated.ApprovedValue = reimbursement.ApprovedValue;
                reimbursementToBeUpdated.InternalNotes = reimbursement.InternalNotes;

                await _context.SaveChangesAsync();

                return reimbursementToBeUpdated;
            }

            return null;
        }

        public async Task<ReimbursementDomain> DeclineReimbursement(int id)
        {
            var reimbursementToBeUpdated = await _context.Reimbursements.FirstOrDefaultAsync(x => x.Id == id);
            if (reimbursementToBeUpdated != null)
            {
                reimbursementToBeUpdated.ApprovalStatus = "Declined";

                await _context.SaveChangesAsync();

                return reimbursementToBeUpdated;
            }
            return null;
        }
    }
}
