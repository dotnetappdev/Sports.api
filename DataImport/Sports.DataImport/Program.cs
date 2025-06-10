using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sports.Services;
using Sports.Services.Interface;

namespace Sports.DataImport
{
    internal class Program
    {

        ISportsDataInterface service = new SportsDataService();

        static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                       .ConfigureServices(services =>
                       {
                           services.AddScoped<ISportsDataInterface, SportsDataService>();
                       })
                       .Build();

            var processor = host.Services.GetRequiredService<ISportsDataInterface>();
            string url = "https://myth.fra1.digitaloceanspaces.com/misc/528%20%281%29.json"; // Replace with your actual URL
            var test = await processor.LoadFromJsonUrlAsync(url);

            var test3 = 2;

        }
    }
}
