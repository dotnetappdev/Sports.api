using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string key { get; set; }
        public string value { get; set; }
        // Foreign key to Sport
        public string SportId { get; set; }
        public Sport Sport { get; set; }
    }
}
