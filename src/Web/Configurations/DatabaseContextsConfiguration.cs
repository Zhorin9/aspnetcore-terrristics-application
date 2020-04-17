using Auth;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configurations
{
    public static class DatabaseContextsConfiguration
    {
        internal static void RegisterDbContexts(IServiceCollection services, IConfiguration configuration)
        {
            RegisterDomainContext(services, configuration);
            RegisterIdentityContext(services, configuration);
        }
        
        /// <summary> Register db context for domain models </summary>
        private static void RegisterDomainContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(c =>
                c.UseMySQL(configuration.GetConnectionString("AppDbContext")));
        }

        /// <summary> Register db context for identity models </summary>
        private static void RegisterIdentityContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseMySQL(configuration.GetConnectionString("AppIdentityDbContext")));
        }
    }
}