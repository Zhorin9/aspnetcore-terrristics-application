using Application;
using Application.Common.Interfaces;
using Auth;
using Common.Interfaces;
using DataAccess;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
            services.AddAuth(Configuration);
            services.AddDataAccess(Configuration);
            services.AddApplication();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services
                .AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IAppDbContext>());

            services.AddCors(o => o.AddPolicy("AllowOrigin", builder =>
            {
                builder
                    .WithOrigins("http://localhost:5000")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            SpaConfiguration.RegisterStaticFiles(services, Configuration);
            OptionsConfiguration.RegisterOptions(services, Configuration);
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
            app.UseRouting();
            app.UseCors("AllowOrigin");
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            // SpaConfiguration.EnableSpa(app, env, Configuration);
        }
    }
}