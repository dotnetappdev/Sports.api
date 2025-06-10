using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class Property
    {

        [Key]
        public int PropertyId { get; set; }
        public int key { get; set; }
        public Value? values { get; set; }

        // Foreign key to Sport
        public string SportId { get; set; }
        public Sport Sport { get; set; }

    }
}
