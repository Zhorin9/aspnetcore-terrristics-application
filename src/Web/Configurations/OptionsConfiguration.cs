using Common.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Configurations
{
    public static class OptionsConfiguration
    {
        internal static void RegisterOptions(IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettingsOption>(appSettingsSection);
        }

    }
}