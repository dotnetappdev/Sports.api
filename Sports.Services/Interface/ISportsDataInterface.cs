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
        public Task<Sport> LoadFromJsonUrlAsync(string url);

    }
}
