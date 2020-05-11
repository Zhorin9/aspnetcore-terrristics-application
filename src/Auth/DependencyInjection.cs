using Application.Common.Interfaces;
using Auth.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserManager, UserManagerService>();

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("AppIdentityDbContext")));
            services.AddAuthentication();
            
            services.AddIdentity<ApplicationUser, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            return services;
        }
    }
}
