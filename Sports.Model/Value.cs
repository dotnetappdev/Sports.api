using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class Value
    {
        [Key]
        public int ValuesId { get; set; }
        public string id { get; set; }
        public string value { get; set; }

        // Foreign key to Sport
        public int SportsId { get; set; }
        public Sport Sport { get; set; }
    }
}
