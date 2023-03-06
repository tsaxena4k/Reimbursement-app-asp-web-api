using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;

namespace TSReimbursementApp.DAL.Repositories.IRepository
{
    public interface IAdminRepository
    {
        public Task<ReimbursementDomain> ApproveReimbursement(int id, ReimbursementDomain reimbursement);
        public Task<ReimbursementDomain> DeclineReimbursement(int id);

    }
}
