using Auth.Identity.Seeds;
using DataAccess;
using DataAccess.Repositories;
using Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configurations
{
    public static class ServicesConfiguration
    {
        internal static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<AppIdentityDbContextSeed>();
            services.AddTransient<AddDbContextSeed>();
            services.AddScoped(typeof(IAsyncAppRepository<>), typeof(AppRepository<>));

            services.AddScoped<ISensorKindRepository, SensorKindRepository>();
            services.AddScoped<IInputBlockDataRepository, InputBlockDataRepository>();
            services.AddScoped<IOutputBlockDataRepository, OutputBlockDataRepository>();
        }
    }
}