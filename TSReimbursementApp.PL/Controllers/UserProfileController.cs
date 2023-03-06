using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.Repositories.IRepository;

namespace TSReimbursementApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private IMapper mapper;
        public UserProfileController(IUserProfileRepository userProfileRepository,IMapper mapper)
        {
            this._userProfileRepository = userProfileRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            System.Diagnostics.Debug.WriteLine(userId);
            var result = await _userProfileRepository.GetUserProfile(userId);
            return result;
        }
    }
}
