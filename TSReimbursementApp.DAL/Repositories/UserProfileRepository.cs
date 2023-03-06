using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Claims;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.Repositories.IRepository;

namespace TSReimbursementApp.DAL.Repositories
{
    public class UserProfileRepository:IUserProfileRepository
    {
        private UserManager<ApplicationUser> _userManager;
        public UserProfileRepository(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Object> GetUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
                user.FullName,
                user.Email,
                user.UserName,
                user.PANNumber,
                user.Bank,
                user.BankAccNumber,
                user.PhoneNumber
            };
        }
    }
}
