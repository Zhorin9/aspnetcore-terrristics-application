using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Auth.Identity;
using Auth.Interfaces;
using Common.Models;
using Common.Options;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auth.Services
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<AppSettingsOption> _appSettings;

        public UserManagerService(UserManager<ApplicationUser> userManager, IOptions<AppSettingsOption> appSettings)
        {
            _userManager = userManager;
            _appSettings = appSettings;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            IdentityResult result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }

        public async Task<ApplicationUser> GetByEmail(string email)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(email);

            return user;
        }

        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
        public string GenerateToken(ApplicationUser user)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Value.Secret);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
