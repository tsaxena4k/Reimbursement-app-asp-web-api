using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.DTOs;

namespace TSReimbursementApp.BL.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<IdentityResult> AddUser(SignupDTO signupUser);

        public Task<object> Login(LoginDTO loginUser);

        public Task<Boolean> Logout(string userId);

    }
}
