
using Microsoft.EntityFrameworkCore;
using Serilog;
using Sports.Infrastructure;
using Sports.Models;
using Sports.Services;
using Sports.Services.Interface;
using System.Configuration;

namespace Sports.api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();



            var connectionstring = appSettings.GetDefaultConnection();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionstring,    options =>
            {
                options.CommandTimeout(180); // timeout in seconds (e.g., 180 seconds = 3 minutes)
            }));
            builder.Services.AddScoped<ISportsDataInterface, SportsDataService>();            
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                // Add the JsonStringEnumConverter to the options for string enum serialization
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());            
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
               
           
        });

            // 🔧 Configure Serilog first
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            // Replace default logging
            builder.Host.UseSerilog();

            builder.Services.AddOpenApi();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Sports API",
                    Version = "v1",
                    
                });

 
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.MapOpenApi();
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //  c.RoutePrefix = "api"; // Set the Swagger UI to be served at /api
            });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
