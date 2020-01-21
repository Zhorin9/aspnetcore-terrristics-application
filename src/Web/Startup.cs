﻿using System.IO;
using System.Text;
using AppCore.Interfaces;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Infrastructure.Identity;
using Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using VueCliMiddleware;
using Web.Mappings;

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

            AutoMapperRegistration(services);
            ServiceRegistration(services);

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
        }

        private static void ServiceRegistration(IServiceCollection services)
        {
            services.AddTransient<AppIdentityDbContextSeed>();
            services.AddTransient<AddDbContextSeed>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggingAdapter<>));
            services.AddScoped(typeof(IAsyncAppRepository<>), typeof(AppRepository<>));

            services.AddScoped<ITerraristicWindowRepository, TerraristicWindowRepository>();
            services.AddScoped<ISensorBlockRepository, SensorBlockRepository>();
            services.AddScoped<ISensorKindRepository, SensorKindRepository>();
        }

        private void AutoMapperRegistration(IServiceCollection services)
        {
            IMapper mapper = MappingConfiguration.GetMapperConfiguration().CreateMapper();
            services.AddSingleton(mapper);
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

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors("AllowOrigin");
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                  "{controller}/{action}/{id?}",
                  new { controller = "Home", Action = "Index" });
            });

//            app.UseSpa(spa =>
//            {
//                spa.Options.SourcePath = "dist";
//
//                if (env.IsDevelopment())
//                {
//                    spa.UseVueCli(npmScript: "serve", port: 8080);
//                }
//            });
        }
    }
}
