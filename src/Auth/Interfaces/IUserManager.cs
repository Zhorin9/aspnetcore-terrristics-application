using System.Threading.Tasks;
using Auth.Identity;
using Common.Models;

namespace Auth.Interfaces
{
    public interface IUserManager
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);

        string GenerateToken(ApplicationUser user);
    }
}
