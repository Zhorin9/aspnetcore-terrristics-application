﻿using System;
using Auth;
using Auth.Identity;
using Auth.Identity.Seeds;
using DataAccess;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args)
                .Build();

            SeedDb(host);

            host.Run();
        }

        private static void SeedDb(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                try
                {
                    //Seed application database with sensor dictionary
                    var applicationSeeder = scope.ServiceProvider.GetService<AddDbContextSeed>();
                    applicationSeeder.SeedAsync().Wait();
                    
                    //Seed identity db context with main user
                    var idendtitySeeder = scope.ServiceProvider.GetService<AppIdentityDbContextSeed>();
                    idendtitySeeder.SeedAsync().Wait();
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Problem with seeding the DB");
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((context, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConfiguration(context.Configuration.GetSection("Logging"));
                    logging.AddDebug();
                    logging.AddConsole();
                })
                .ConfigureAppConfiguration(SetupConfiguration)
                .UseStartup<Startup>();

        private static void SetupConfiguration(WebHostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.Sources.Clear();

            builder.AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables();
        }
    }
}