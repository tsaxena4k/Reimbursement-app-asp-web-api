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
    public class DatabaseRefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ReimbursementContext _context;

        public DatabaseRefreshTokenRepository(ReimbursementContext context)
        {
            _context = context;
        }

        public async Task Create(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            RefreshToken refreshToken = await _context.RefreshTokens.FindAsync(id);
            if (refreshToken != null)
            {
                _context.RefreshTokens.Remove(refreshToken);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAll(string userId)
        {
            IEnumerable<RefreshToken> refreshTokens = await _context.RefreshTokens
                .Where(t => t.UserId == userId)
                .ToListAsync();

            _context.RefreshTokens.RemoveRange(refreshTokens);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetByToken(string token)
        {
            return await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);
        }
    }
}
