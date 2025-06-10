using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Sports.Services.Interface;

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


    
              [HttpGet("{id}")]
        public async Task<IActionResult> Search([FromQuery] SortDirectionEnum orderDirection,)
        {

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
