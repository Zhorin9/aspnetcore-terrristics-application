using Auth.Identity.Seeds;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configurations
{
    public static class ServicesConfiguration
    {
        internal static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<AppIdentityDbContextSeed>();
            services.AddTransient<AddDbContextSeed>();
        }
    }
}