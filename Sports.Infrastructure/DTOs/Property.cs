using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Infrastructure.DTOs
{
    public class Property
    {


        public int key { get; set; }
        [NotMapped]
        public Value value { get; set; }
    }
}
