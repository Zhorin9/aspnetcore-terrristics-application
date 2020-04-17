using System.Text;
using Domain.Interfaces;
using Auth;
using DataAccess;
using DataAccess.Logging;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Web.Configurations;

namespace Web
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            DatabaseContextsConfiguration.RegisterDbContexts(services, _config);
            AutoMapperConfiguration.RegisterAutoMapper(services);
            SpaConfiguration.RegisterStaticFiles(services, _config);
            
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

            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver())
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            RegisterInterfaces(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

//            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                SpaConfiguration.EnableStaticFiles(app);
            }

            app.UseAuthentication();
            app.UseCors("AllowOrigin");
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                    "{controller}/{action}/{id?}",
                    new {controller = "Home", Action = "Index"});
            });
            
            SpaConfiguration.EnableSpa(app, env, _config);
        }
        
        private static void RegisterInterfaces(IServiceCollection services)
        {
            services.AddTransient<AppIdentityDbContextSeed>();
            services.AddTransient<AddDbContextSeed>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggingAdapter<>));
            services.AddScoped(typeof(IAsyncAppRepository<>), typeof(AppRepository<>));

            services.AddScoped<ITerraristicWindowRepository, TerraristicWindowRepository>();
            services.AddScoped<ISensorBlockRepository, SensorBlockRepository>();
            services.AddScoped<ISensorKindRepository, SensorKindRepository>();
            services.AddScoped<IInputBlockDataRepository, InputBlockDataRepository>();

            services.AddIdentity<ApplicationUser, IdentityRole>(cfg => { cfg.User.RequireUniqueEmail = true; })
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }
    }
}