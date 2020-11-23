using System.Threading.Tasks;
using Common.Models;
using Domain.Entities;

namespace Auth.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(string userId);
        Task<ApplicationUser> GetByEmail(string email);
        string GenerateToken(ApplicationUser user);
    }
}