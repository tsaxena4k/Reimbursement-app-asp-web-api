using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;

namespace TSReimbursementApp.DAL.Repositories.IRepository
{
    public interface IAccountRepository
    {
        //Task<IList<UserDTO>> GetUsers();
        Task<IdentityResult> AddUser(SignupDomain user);
        Task<object> Login(LoginDomain user);

        Task<Boolean> Logout(string userId);

        //Task<UserDTO> GetUserByEmail(string email);
    }
}
