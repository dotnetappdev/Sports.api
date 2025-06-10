using Microsoft.AspNetCore.Mvc;
using Sports.Infrastructure.DTOs;
using Sports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Services.Interface
{
    public interface ISportsDataInterface
    {
        public Task<List<Sport>> LoadFromJsonUrlAsync(string url);

        public Task<Sports.Models.Sport> GetById(string Id);

        public async IQueryable<Sports.Models.Sport> Search(IQueryable<Sports.Models.Sport> query, [FromQuery] Enums.SearchField searchField, string searchValue)

    }
}
