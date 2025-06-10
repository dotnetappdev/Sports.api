
using Microsoft.EntityFrameworkCore;
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
            options.UseSqlServer(connectionstring));
            builder.Services.AddScoped<ISportsDataInterface, SportsDataService>();            
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                // Add the JsonStringEnumConverter to the options for string enum serialization
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });
            builder.Services.AddOpenApi();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Sports API",
                    Version = "v1"
                });


                var filePath = Path.Combine(System.AppContext.BaseDirectory, "MyApi.xml");
                c.IncludeXmlComments(filePath);

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
