using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class NavigationInfo
    {
        [Key]
        public int NavigationInfoId { get; set; }

        public int key { get; set; }
        public string? value { get; set; }
        public bool? has_standings { get; set; }
        public bool? is_knockout { get; set; }

        // Foreign key to Sport
        public int SportsId { get; set; }
        public Sport Sport { get; set; }
    }
}
