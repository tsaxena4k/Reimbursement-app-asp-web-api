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
    public class ReimbursementRepository:IReimbursementRepository
    {
        private readonly ReimbursementContext _context;
        
        public ReimbursementRepository(ReimbursementContext context)
        {
            this._context = context;
        }

        public async Task<ReimbursementDomain> GetReimbursement(int id)
        {
            return await _context.Reimbursements.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<ReimbursementDomain>> GetReimbursementByEmail(string email)
        {
            var result = from _reimburse in _context.Reimbursements
                         where _reimburse.UserId == email
                         orderby _reimburse.Date
                         select _reimburse;
            return await result.ToListAsync();
        }

        public async Task<IList<ReimbursementDomain>> GetAllReimbursements()
        {
            var result = await _context.Reimbursements.OrderBy(x => x.Date).ToListAsync();
            return result;
        }

        public async Task<ReimbursementDomain> AddReimbursement(ReimbursementDomain reimbursement)
        {
            var newReimbursement = new ReimbursementDomain()
            {
                Date = reimbursement.Date,
                ReimbursementType = reimbursement.ReimbursementType,
                RequestedValue = reimbursement.RequestedValue,
                Currency = reimbursement.Currency,
                Image = reimbursement.Image,
                UserId=reimbursement.UserId
            };

            await _context.Reimbursements.AddAsync(newReimbursement);
            await _context.SaveChangesAsync();

            return newReimbursement;
        }

        public async Task<ReimbursementDomain> DeleteReimbursement(int id)
        {
            var reimbursement = await _context.Reimbursements.FirstOrDefaultAsync(x => x.Id == id);
            if (reimbursement != null)
            {
                _context.Reimbursements.Remove(reimbursement);
                await _context.SaveChangesAsync();
                return reimbursement;
            }
            return null;
        }

        public async Task<ReimbursementDomain> UpdateReimbursement(int id, ReimbursementDomain reimbursement)
        {
            var reimbursementToBeUpdated = await _context.Reimbursements.FirstOrDefaultAsync(x => x.Id == id);
            if (reimbursementToBeUpdated != null)
            {
                reimbursementToBeUpdated.Date = reimbursement.Date;
                reimbursementToBeUpdated.ReimbursementType = reimbursement.ReimbursementType;
                reimbursementToBeUpdated.RequestedValue = reimbursement.RequestedValue;
                reimbursementToBeUpdated.Currency = reimbursement.Currency;
                reimbursementToBeUpdated.Image = reimbursement.Image;

                await _context.SaveChangesAsync();

                return reimbursementToBeUpdated;
            }

            return null;
        }
        
    }
}
