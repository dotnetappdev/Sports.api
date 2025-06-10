using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class Meta
    {

        public long? update_id { get; set; }
        public bool update_idSpecified { get; set; }
        public string update_action { get; set; }
        public DateTime update_date { get; set; }
        public string language { get; set; }
    }
}
