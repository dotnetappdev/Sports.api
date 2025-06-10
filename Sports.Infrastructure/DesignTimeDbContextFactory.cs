using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Sports.Models;

namespace Sports.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            string webApiProjectPath = Path.Combine(Directory.GetCurrentDirectory(), "../Sports.api/Sports.api/");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // Use your actual connection string here or load from config
            IConfiguration config = new ConfigurationBuilder()
              .SetBasePath(webApiProjectPath) // Point to the Web API project folder
              .AddJsonFile("appsettings.json")
              .Build();

            var appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings);

            var connectionString = appSettings.GetDefaultConnection();
            optionsBuilder.UseSqlServer(connectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}