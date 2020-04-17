using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Auth
{
    /// <summary>
    /// Used for creating DBContext in design time, for example for handling migrations. Automatically detected by the environment.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory() + "/../Web/")
                .AddJsonFile("appsettings.json")
                .Build();
            
            var builder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            var connectionString = configuration.GetConnectionString("AppIdentityDbContext");
            builder.UseMySQL(connectionString);
            return new AppIdentityDbContext(builder.Options);
        }
    }
}