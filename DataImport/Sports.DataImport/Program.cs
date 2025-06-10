using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sports.Infrastructure;
using Sports.Models;
using Sports.Services;
using Sports.Services.Interface;

namespace Sports.DataImport
{
    internal class Program
    {


        static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "Production"}.json", optional: true)
          .AddEnvironmentVariables()
          .AddCommandLine(args)
          .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var host = Host.CreateDefaultBuilder(args)
              .ConfigureServices(services =>
              {
                  // Register ApplicationDbContext with your connection string
                  services.AddDbContext<ApplicationDbContext>(options =>
                      options.UseSqlServer(connectionString));

                  services.AddScoped<ISportsDataInterface, SportsDataService>();
              })
              .Build();

            var processor = host.Services.GetRequiredService<ISportsDataInterface>();
            string url = "https://myth.fra1.digitaloceanspaces.com/misc/528%20%281%29.json";
            List<Sport> test = await processor.LoadFromJsonUrlAsync(url);
            var test2 = processor.SaveData(test);
            Console.WriteLine($"Data saved successfully. Number of records: {test.Count()}");
            Console.ReadLine();
        }
    }
}
