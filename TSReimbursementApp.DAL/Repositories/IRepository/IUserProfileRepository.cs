using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSReimbursementApp.DAL.Repositories.IRepository
{
    public interface IUserProfileRepository
    {
        Task<Object> GetUserProfile(string userId);
    }
}
