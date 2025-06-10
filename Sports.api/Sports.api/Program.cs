
using Microsoft.EntityFrameworkCore;
using Sports.Infrastructure;
using Sports.Models;
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

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
