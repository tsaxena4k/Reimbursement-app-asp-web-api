using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;

namespace TSReimbursementApp.DAL.Repositories.IRepository
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetByToken(string token);

        Task Create(RefreshToken refreshToken);

        Task Delete(int id);

        Task DeleteAll(string userId);
    }
}
