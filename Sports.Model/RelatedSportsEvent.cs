using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class RelatedSportsEvent
    {

        public string id { get; set; }
        public string type { get; set; }
        public string type_detail { get; set; }
        public string depth { get; set; }
        public NavigationInfo navigation_info { get; set; }
    }
}
