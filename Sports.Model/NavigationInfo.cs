using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class NavigationInfo
    {
        public int key { get; set; }
        public string? value { get; set; }
        public bool? has_standings { get; set; }
        public bool? is_knockout { get; set; }
    }
}
