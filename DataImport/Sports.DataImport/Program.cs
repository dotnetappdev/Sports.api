using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Sports.Infrastructure;
using Sports.Infrastructure.DTOs;
using Sports.Models;
using Sports.Services;
using Sports.Services.Interface;
using Sports.Services.Mapping;
using System.Collections.Generic;

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

            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();


            Log.Logger = new LoggerConfiguration()
       .Enrich.FromLogContext()
       .WriteTo.Console()
       .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
       .CreateLogger();

            // Replace defaul
            var host = Host.CreateDefaultBuilder(args)
               .UseSerilog() // ✅ Attach Serilog here
              .ConfigureServices(services =>
              {
                  // Register ApplicationDbContext with your connection string
                  services.AddDbContext<ApplicationDbContext>(options =>
                      options.UseSqlServer(connectionString));

                  services.AddScoped<ISportsDataInterface, SportsDataService>();
 
              })
              .Build();

          

            var processor = host.Services.GetRequiredService<ISportsDataInterface>();
            string url = appSettings.APIUrl;
            if (string.IsNullOrEmpty(url))
            {
                Console.WriteLine("API URL is not configured in appsettings.json.");
                return;
            }
            SportAPIResponse dataFromService = await processor.LoadFromJsonUrlAsync(url);
            var data = (List<Sports.Infrastructure.DTOs.Sport>)dataFromService.Data;

            try
            {
                var transformedData = SportsMapper.SportDTOToSport(data);
                var saveData = processor.SaveData(transformedData);
            }catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while processing the data: {ex.Message}");
             
            }
            Console.WriteLine($"Data saved successfully. Number of records: {data.Count()}");
            Console.ReadLine();
        }
    }
}
