using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class AppSettings
    {
        public string JwtSecret { get; set; } = string.Empty;

        public string BaseAddress { get; set; }
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; } = 0;
        public Dictionary<string, string> ConnectionStrings { get; set; } = new();


        public string GetDefaultConnection()
        {
            return this.ConnectionStrings["DefaultConnection"];
        }
    }
}
