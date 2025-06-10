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
        public Task<SportAPIResponse> LoadFromJsonUrlAsync(string url);

        public Task<Sports.Models.Sport?> GetById(int Id);
        public IQueryable<Sports.Models.Sport> GetAll();
        public Task<SportAPIResponse> Search(IQueryable<Sports.Models.Sport> query, [FromQuery] SearchFieldEnum searchField, string searchValue);

        public  SportAPIResponse SaveData(List<Sports.Models.Sport> sportsData);

    }
}
