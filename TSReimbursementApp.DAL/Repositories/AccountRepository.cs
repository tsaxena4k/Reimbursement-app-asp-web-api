using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TSReimbursementApp.DAL.DBContext;
using TSReimbursementApp.DAL.Domain;
using TSReimbursementApp.DAL.Repositories.IRepository;

namespace TSReimbursementApp.DAL.Repositories
{
    public class AccountRepository:IAccountRepository
    {
        private IMapper mapper;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly AuthenticationConfiguration _configuration;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mapper, AuthenticationConfiguration configuration, IRefreshTokenRepository refreshTokenRepository)
        {
            this.mapper = mapper;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._configuration = configuration;
            this._refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<IdentityResult> AddUser(SignupDomain user)
        {
            var newUser = new ApplicationUser()
            {
                UserName = user.Email,
                Email = user.Email,
                PANNumber = user.PANNumber,
                Bank = user.Bank,
                BankAccNumber = user.BankAccNumber,
                FullName = user.FullName
            };

            var result=await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                //_logger.LogInformation("User created a new account with password.");
                await _userManager.AddToRoleAsync(newUser, Enums.Roles.Basic.ToString());
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            }
            return result;
        }

        //public async Task<IList<UserDTO>> GetUsers()
        //{
        //    //var allEvents = await _eventContext.Events.ToListAsync();
        //    //return DataSource();
        //    var result = await _userManager.
        //    return mapper.Map<IList<UserDTO>>(result);

        //}

        //public async Task<UserDTO> GetUserByEmail(string email)
        //{
        //    var result = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

        //    return mapper.Map<UserDTO>(result);
        //}

        public async Task<object> Login(LoginDomain user)
        {
            //var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, true, false);
            //return result;
            var loginUser = await _userManager.FindByEmailAsync(user.Email);
            if (loginUser != null && await _userManager.CheckPasswordAsync(loginUser, user.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", loginUser.Id.ToString()),
                        new Claim("UserEmail", loginUser.Email.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                RefreshToken refreshTokenDTO = new RefreshToken()
                {
                    Token=token,
                    UserId=loginUser.Id
                };

                await _refreshTokenRepository.Create(refreshTokenDTO);
                var roleList = await _userManager.GetRolesAsync(loginUser);

                return new { token = token,user=loginUser,role=roleList[0]};
            }
            else
                return new
                {
                    Error="Username or password invalid"
                };
        }

        public async Task<Boolean> Logout(string userId)
        {

            await _refreshTokenRepository.DeleteAll(userId);

            return true;
        }

    }
}
