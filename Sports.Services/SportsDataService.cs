using Microsoft.EntityFrameworkCore;
using Sports.Infrastructure;
using Sports.Models;
using Sports.Services.Interface;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sports.Services
{
    public class SportsDataService : ISportsDataInterface
    {
        private readonly ApplicationDbContext _context;
        SportsDataService(ApplicationDbContext context)

        {
            _context = context;
        }
        public async Task<List<Sport>> LoadFromJsonUrlAsync(string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            using var stream = await response.Content.ReadAsStreamAsync();

            options.Converters.Add(new NavigationInfoJsonConverter());
            var sportsData = await JsonSerializer.DeserializeAsync<List<Sport>>(stream, options);
            if (sportsData == null)
                throw new InvalidOperationException("Failed to deserialize JSON data.");
            return sportsData;
        }

        public void SaveData(int Id)
        {


        }

    }
}