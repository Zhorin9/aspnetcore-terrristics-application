using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application;
using Application.Common.Interfaces;
using Auth;
using Common.Interfaces;
using DataAccess;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Web.Configurations;
using Web.Services;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            SpaConfiguration.RegisterStaticFiles(services, Configuration);

            services.AddAuth(Configuration);
            services.AddDataAccess(Configuration);
            services.AddApplication();
            
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services
                .AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                {
                    options.UseMemberCasing();
                })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IAppDbContext>());

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
            
            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            
            JwTAuthenticationConfiguration.RegisterJwtAuthentication(services, Configuration);           
            ServicesConfiguration.RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllers();
            // });
            
            // // // app.UseHttpsRedirection();
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute("default", "{controller}/{action=index}/{id}");
            // });
            //
            // // global cors policy
            // app.UseCors(x => x
            //     .AllowAnyOrigin()
            //     .AllowAnyMethod()
            //     .AllowAnyHeader());
            //
            //
            // app.UseEndpoints(endpoints => {
            //     endpoints.MapControllers();
            // });
            
            // SpaConfiguration.EnableSpa(app, env, Configuration);
        }
    }
}