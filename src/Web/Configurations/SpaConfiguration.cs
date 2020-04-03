using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VueCliMiddleware;

namespace Web.Configurations
{
    public static class SpaConfiguration
    {
        internal static void RegisterStaticFiles(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSpaStaticFiles(cfg => { cfg.RootPath = configuration["Spa:RootPath"]; });
        }

        /// <summary> Static files should be enabled only for non development environments </summary>
        internal static void EnableStaticFiles(IApplicationBuilder app)
        {
            app.UseSpaStaticFiles();
        }

        internal static void EnableSpa(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration)
        {
            app.UseSpa(spa =>
            {              
                spa.Options.SourcePath = configuration["Spa:SourcePath"];
                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });
        }
    }
}