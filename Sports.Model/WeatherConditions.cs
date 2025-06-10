using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Models
{
    public class WeatherConditions
    {
        public int temperature_fahrenheit { get; set; }
        public bool temperature_fahrenheitSpecified { get; set; }
        public double temperature_celsius { get; set; }
        public bool temperature_celsiusSpecified { get; set; }
        public int wind_speed_miles { get; set; }
        public bool wind_speed_milesSpecified { get; set; }
        public double wind_speed_kilometers { get; set; }
        public bool wind_speed_kilometersSpecified { get; set; }
        public int wind_direction { get; set; }
        public bool wind_directionSpecified { get; set; }
        public int weather_type { get; set; }
        public bool weather_typeSpecified { get; set; }
        public object tail_wind_speed { get; set; }
        public int baseball_home_plate_wind_direction { get; set; }
        public bool baseball_home_plate_wind_directionSpecified { get; set; }
    }
}
