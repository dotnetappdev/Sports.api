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

        public void GetById(int Id);

        public int SaveData(List<Sport> sportsData);

    }
}
