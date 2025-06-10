using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Sports.Models
{
    public class RelatedSportsEvent
    {


        [Key]
        public int RelatedSportsEventId { get; set; }
        public string? id { get; set; }
        public string? type { get; set; }
        public string? type_detail { get; set; }
        public string? depth { get; set; }
        public NavigationInfo? navigation_info { get; set; }
        public int SportsId { get; set; }
        public Sport Sport { get; set; }
    }
}
