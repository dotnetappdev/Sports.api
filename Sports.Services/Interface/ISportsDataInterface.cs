using Microsoft.AspNetCore.Mvc;
using Sports.Infrastructure.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sports.Services.SportsDataService;

namespace Sports.Services.Interface
{
    public interface ISportsDataInterface
    {
        public Task<List<Sports.Infrastructure.DTOs.Sport>> LoadFromJsonUrlAsync(string url);

        public Task<Sports.Models.Sport> GetById(string Id);
        public async Task<List<Sports.Models.Sport>?> GetAll();

        public IQueryable<Sports.Models.Sport> Search(List<Sports.Models.Sport> query, [FromQuery] SearchFieldEnum searchField, string searchValue);

    }
}
