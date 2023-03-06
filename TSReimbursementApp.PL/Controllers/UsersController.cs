using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TSReimbursementApp.BL.Services.Interfaces;
using TSReimbursementApp.DAL.DBContext;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.DTOs;
using TSReimbursementApp.DAL.Repositories;
using TSReimbursementApp.DAL.Repositories.IRepository;
using TSReimbursementApp.PL.Models;

namespace TSReimbursementApp.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IAccountService _accountService;
        private UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(IAccountService accountService,IMapper mapper, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._accountService = accountService;
            this.mapper = mapper;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        //// GET: api/Users
        //[HttpGet("GetUsers")]
        //public async Task<IList<UserViewModel>> GetUsers()
        //{
        //    var result = await _userManager.GetUsers();
        //    return mapper.Map<IList<UserViewModel>>(result);
        //}

        // POST: api/Users
        [HttpPost("RegisterUser")]

        public async Task<IdentityResult> AddUser(SignupModel user)
        {
            
            System.Diagnostics.Debug.WriteLine(user);
            SignupDTO u = mapper.Map<SignupModel, SignupDTO>(user);
            return await _accountService.AddUser(u);
        }

        [HttpPost]
        [Route("Login")]
        //POST : /api/Users/Login
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            var loginUser = await _userManager.FindByEmailAsync(user.Email);
            if (loginUser == null)
            {
                return Unauthorized();
            }
            bool isCorrectPassword = await _userManager.CheckPasswordAsync(loginUser, user.Password);
            if (!isCorrectPassword)
            {
                return Unauthorized();
            }
            LoginDTO loginData = mapper.Map<LoginViewModel, LoginDTO>(user);
            var result = await _accountService.Login(loginData);

            return Ok(result);
        }


        [HttpGet]
        [Route("Logout")]
        //POST : /api/Users/Logout
        public async Task<Boolean> Logout(string userId)
        {
            //var userId = User.Claims.First(c => c.Type == "UserID").Value;
            Debug.WriteLine(userId);
            return await _accountService.Logout(userId);
        }

        [HttpGet]
        [Route("GetRole")]
        //GET : /api/Users/GetRole

        public async Task<string> GetRole()
        {
            var userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var roleList = await _userManager.GetRolesAsync(user);
            return roleList[0];
        }
    }
}
