using System.Globalization;
using System.Text;
using AppCore.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VueCliMiddleware;

namespace TerrristicsApp
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Add DbContext for application
            services.AddDbContext<AppDbContext>(c =>
               c.UseSqlServer(_config.GetConnectionString("AppDbContext")));

            services.AddAuthentication()
                .AddCookie()
                .AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                    };
                });

            //Add DbContext for users identity
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(_config.GetConnectionString("AppIdentityDbContext")));

            services.AddIdentity<ApplicationUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddTransient<AppIdentityDbContextSeed>();
            services.AddTransient<AddDbContextSeed>();
            services.AddScoped(typeof(IAsyncAppRepository<>), typeof(AppRepository<>));
            services.AddScoped<ITerraristicWindowRepository, TerraristicWindowRepository>();

            //TODO To remove services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            //TODO To remove var supportedCultures = new[]
            //{
            //    new CultureInfo("pl-PL"),
            //};
            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("pl-PL"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures
            //});

            app.UseAuthentication();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                  "{controller}/{action}/{id?}",
                  new { controller = "Home", Action = "Index" });
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "client-app";

                if (env.IsDevelopment())
                {
                    // run npm process with client app
                    spa.UseVueCli(npmScript: "serve", port: 8080);
                    // if you just prefer to proxy requests from client app, use proxy to SPA dev server instead:
                    // app should be already running before starting a .NET client
                    // spa.UseProxyToSpaDevelopmentServer("http://localhost:8080"); // your Vue app port
                }
            });
        }
    }
}
