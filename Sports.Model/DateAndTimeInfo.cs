using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class DateAndTimeInfo
    {
        [JsonIgnore]
        public int Id { get; set; }
        public DateTime scheduled_start_time_utc { get; set; }
        public bool scheduled_start_time_utcSpecified { get; set; }
        public DateTime scheduled_end_time_utc { get; set; }
        public bool scheduled_end_time_utcSpecified { get; set; }
        public DateTime actual_start_time_utc { get; set; }
        public bool actual_start_time_utcSpecified { get; set; }
        public DateTime actual_end_time_utc { get; set; }
        public bool actual_end_time_utcSpecified { get; set; }
        public DateTime start_date_local { get; set; }
        public bool start_date_localSpecified { get; set; }
        public DateTime end_date_local { get; set; }
        public bool end_date_localSpecified { get; set; }
    }

}