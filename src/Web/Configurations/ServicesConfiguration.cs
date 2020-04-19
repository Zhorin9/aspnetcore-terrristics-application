using Auth;
using DataAccess;
using DataAccess.Logging;
using DataAccess.Repositories;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configurations
{
    public static class ServicesConfiguration
    {
        internal static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<AppIdentityDbContextSeed>();
            services.AddTransient<AddDbContextSeed>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggingAdapter<>));
            services.AddScoped(typeof(IAsyncAppRepository<>), typeof(AppRepository<>));

            services.AddScoped<ITerraristicWindowRepository, TerraristicWindowRepository>();
            services.AddScoped<ISensorBlockRepository, SensorBlockRepository>();
            services.AddScoped<ISensorKindRepository, SensorKindRepository>();
            services.AddScoped<IInputBlockDataRepository, InputBlockDataRepository>();
            services.AddScoped<IOutputBlockDataRepository, OutputBlockDataRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }
    }
}