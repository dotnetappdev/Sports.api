using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Sports.Services.Interface;
using static Sports.Models.Enums;
using static Sports.Services.SportsDataService;

namespace Sports.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ISportsDataInterface _sportsDataInterface;
        public SportsController(ISportsDataInterface sportsDataInterface)
        {
            _sportsDataInterface = sportsDataInterface;

        }


        /// <summary>
        /// Searches the specified search field.
        /// </summary>
        /// <param name="searchField">The search field.</param>
        /// <param name="searchPhrase">The search phrase.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Search( [FromQuery] SearchFieldEnum searchField,string searchPhrase)
        {
            if (string.IsNullOrEmpty(searchPhrase))
            {
                return BadRequest("Search phrase cannot be null or empty.");
            }
            var sports = await _sportsDataInterface.GetAll();
            if (sports == null || !sports.Any())
            {
                return NotFound("No sports found.");
            }
            var filtersports =_sportsDataInterface.Search(sports, searchField, searchPhrase);

            if (filtersports == null || !filtersports.Any())
            {
                return NotFound($"No sports found for search field {searchField} with phrase '{searchPhrase}'.");
            }
            
            return Ok(filtersports);
            
        }
            /// <summary>
            /// Gets the specified identifier.
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <returns></returns>
            [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id cannot be null or empty.");
            }
            var sport = await _sportsDataInterface.GetById(id);
            if (sport == null)
            {
                return NotFound($"Sport with id {id} not found.");
            }
            return Ok(sport);
        }
    }
}
