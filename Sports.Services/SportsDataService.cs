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
        public readonly ApplicationDbContext _context;
        public SportsDataService()
        {

        }

        public SportsDataService(ApplicationDbContext context)

        {
            _context = context;
        }

        /// <summary>
        /// Gets the sport by id.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public void GetById(string Id)
        {
            var test = _context.Sports.FirstOrDefault(s => s.id == Id);
        }

        public void GetById(int Id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Loads from json URL asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Failed to deserialize JSON data.</exception>
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

        public int SaveData(List<Sport> sportsData)
        {
            _context.Sports.AddRange(sportsData);
            _context.SaveChanges();
            return 1; // Return a Task<int> with a dummy value, as SaveChanges() does not return an int directly

        }

    }
}