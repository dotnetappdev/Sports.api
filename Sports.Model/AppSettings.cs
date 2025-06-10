using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class AppSettings
    {

        public string APIUrl { get; set; }
        public Dictionary<string, string> ConnectionStrings { get; set; } = new();


        public string GetDefaultConnection()
        {
            return this.ConnectionStrings["DefaultConnection"];
        }
    }
}
