using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sports.Infrastructure;
using Sports.Infrastructure.DTOs;

using Sports.Services.Interface;
using Sports.Services.Mapping;
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

        public async Task<List<Sports.Models.Sport>?> GetAll()
        {
            return await _context.Sports.ToListAsync();
        }
        public async Task<Sports.Models.Sport?> GetById(string Id)
        {

            return await _context.Sports.Where(w => w.id == Id).FirstOrDefaultAsync();
        }

        public enum SearchFieldEnum
        {

            description,
            type,
            start_date,
            attendanceSpecified

        }
        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="searchField">The search field.</param>
        /// <param name="searchValue">The search value.</param>
        /// <returns></returns>
        private List<Sports.Models.Sport> Search(IQueryable<Sports.Models.Sport> query, [FromQuery] SearchFieldEnum searchField, string searchValue)
        {

            if (query != null)
            {

                // Apply searchField dynamically based on the 'sortBy' and 'sortOrder' parameters
                switch (searchField.ToString())
                {
                    case "description":
                        query = query.Where(s => s.description.Contains(searchValue, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "type":
                        if (int.TryParse(searchValue, out int typeValue))
                        {
                            query = query.Where(s => s.type == typeValue);
                        }
                        break;
                    case "start_date":
                        if (DateTime.TryParse(searchValue, out DateTime startDateValue))
                        {
                            query = query.Where(s => s.start_date_local.Date == startDateValue.Date);
                        }
                        break;

                    case "attendanceSpecified":
                        if (bool.TryParse(searchValue, out bool attendanceSpecifiedValue))
                        {
                            query = query.Where(s => s.attendanceSpecified != null);
                        }
                        break;
                }
            }

            return query.ToList();
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
            var sportsData = await JsonSerializer.DeserializeAsync<List<Sports.Infrastructure.DTOs.Sport>>(stream, options);
            if (sportsData == null)
                throw new InvalidOperationException("Failed to deserialize JSON data.");
            return sportsData;
        }

        public int SaveData(List<Sports.Models.Sport> sportsData)
        {
            _context.Sports.AddRange(SportsMapper.SportDTOToSport(sportsData));
            _context.SaveChanges();
            return 1; // Return a Task<int> with a dummy value, as SaveChanges() does not return an int directly

        }

        public void SportDtoToSport(Sport sportDto)
        {


        }
    }
}