using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sports.Infrastructure;
using Sports.Infrastructure.DTOs;
using Sports.Models;
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
        private readonly ILogger<SportsDataService> _logger;

        public readonly ApplicationDbContext _context;
        public SportsDataService()
        {

        }

        public SportsDataService(ApplicationDbContext context, ILogger<SportsDataService> logger)

        {
            _context = context;
            _logger = logger;

        }

        public IQueryable<Sports.Models.Sport> GetAll()
        {
            return _context.Sports.Include(c => c.related_sports_events).AsQueryable();
        }
        public async Task<Sports.Models.Sport?> GetById(int Id)
        {

            return await _context.Sports.Where(w => w.SportsId == Id).Include(c=>c.related_sports_events).FirstOrDefaultAsync();
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
        public async  Task<SportAPIResponse> Search(IQueryable<Sports.Models.Sport> query, [FromQuery] SearchFieldEnum searchField, string searchValue)
        {
            try
            {
                if (query != null)
                {

                    // Apply searchField dynamically based on the 'sortBy' and 'sortOrder' parameters
                    switch (searchField.ToString())
                    {
                        case "description":
                            query = query.Where(s => s.description == searchValue);                            
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
                                query = query.Where(s => s.start_date_local.Date >= startDateValue.Date);
                            }
                            break;

                        case "attendanceSpecified":
                            if (bool.TryParse(searchValue, out bool attendanceSpecifiedValue))
                            {
                                query = query.Where(s => s.attendanceSpecified == attendanceSpecifiedValue);
                            }
                            break;
                    }
                }
                var results   = query.ToList(); // Materialize here
                return new SportAPIResponse { Data = results, Success = true };

          
                 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving search results");

                return new SportAPIResponse { Data = null, Message = "Load from Service Failed", StatusCode = 500, Success = false };
            }


        }


        /// <summary>
        /// Loads from json URL asynchronous.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Failed to deserialize JSON data.</exception>
        public async Task<SportAPIResponse> LoadFromJsonUrlAsync(string url)
        {
            try
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

                return new SportAPIResponse { Data = sportsData, Message = "Load from Service Succeded", StatusCode = 200, Success = true };
            }
            catch (Exception ex)
             
            {
                _logger.LogError(ex, "Error retrieving sports");
                return new SportAPIResponse { Data = null, Message = "Load from Service Failed", StatusCode = 500, Success = false };
            }

        }
        public  SportAPIResponse SaveData(List<Sports.Models.Sport> sportsData)
        { 
            if (sportsData == null)
            {
                return new SportAPIResponse { Data = null, Message = "No data to save.", StatusCode = 400, Success = false };
            }

            try
            { 
                 _context.Sports.AddRange(sportsData);
                 _context.SaveChanges();
                return new SportAPIResponse { Data = _context.Sports.ToList(), Message = "Save Sucess", StatusCode = 200, Success = true };

            }
            catch (Exception ex)
            {
                return new SportAPIResponse { Data = _context.Sports.ToList(), Message = "Exception", StatusCode = 500, Success = false,Ex=ex };
            }
        }
    }
}