using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;

namespace TSReimbursementApp.DAL.Repositories.IRepository
{
    public interface IReimbursementRepository
    {
        public Task<ReimbursementDomain> GetReimbursement(int id);
        public Task<IList<ReimbursementDomain>> GetAllReimbursements();
        public Task<IList<ReimbursementDomain>> GetReimbursementByEmail(string email);

        public Task<ReimbursementDomain> AddReimbursement(ReimbursementDomain reimbursement);

        public Task<ReimbursementDomain> DeleteReimbursement(int id);
        public Task<ReimbursementDomain> UpdateReimbursement(int id, ReimbursementDomain reimbursement);

    }
}
