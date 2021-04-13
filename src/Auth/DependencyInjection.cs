using Auth.Identity;
using Auth.Interfaces;
using Auth.Services;
using Domain.Entities;
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
            string connectionString = configuration.GetConnectionString("AppIdentityDbContext");
            services.AddScoped<IUserManager, UserManagerService>();

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            services.AddAuthentication();
            
            services.AddIdentity<ApplicationUser, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<AppIdentityDbContext>();

            return services;
        }
    }
}
