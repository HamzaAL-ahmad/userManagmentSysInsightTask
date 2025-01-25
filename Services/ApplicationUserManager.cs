using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
namespace Services
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using Model;
    using Model.dto;
    using PresistanceSql;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<bool> AddUserAsync(UserInfoDto user, string password)
        {
            var User = new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirmed = true,
                UserInfo = new UserInfo
                {
                    Email = user.Email,
                    Gender = user.Gender,
                    Address = user.Address,
                    Skills = user.Skills,
                    ID_City = user.ID_City,
                }
            };
            var result = await _userManager.CreateAsync(User, password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }




        public async Task<string> LoginAsync(string login, string password)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == login || u.Email == login);
            if (user == null) return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (!result.Succeeded) return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsA32ByteLongSecureKey123456789!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "YourIssuer",
                audience: "YourAudience",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<List<UserInfo>> GetAllUsersAsync()
        {
         return await _dbContext.UsersInfo
        .Include(u => u.ApplicationUser)
        .ToListAsync();
        }
    }
}
