using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.BL.Services.Interfaces;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.DTOs;
using TSReimbursementApp.DAL.Repositories.IRepository;

namespace TSReimbursementApp.BL.Services
{
    public class AccountService:IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private IMapper mapper;

        public AccountService(IAccountRepository accountRepository,IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> AddUser(SignupDTO signupUser)
        {
            if (signupUser == null)
                throw new Exception($"Entity could not be mapped.");

            SignupDomain signupData = mapper.Map<SignupDTO, SignupDomain>(signupUser);

            return await accountRepository.AddUser(signupData);
        }

        public async Task<object> Login(LoginDTO loginUser)
        {
            if (loginUser == null)
                throw new Exception($"Entity could not be mapped.");

            LoginDomain loginData = mapper.Map<LoginDTO, LoginDomain>(loginUser);

            return await accountRepository.Login(loginData);
        }

        public async Task<Boolean> Logout(string userId)
        {
            return await accountRepository.Logout(userId);
        }
    }
}
