using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sports.Infrastructure.DTOs
{
    public class Sport
    {

        public string id { get; set; }

        public string description { get; set; }
        public int type { get; set; }
        public DateTime start_date_local { get; set; }
        public bool start_date_localSpecified { get; set; }
        public DateTime scheduled_start_time_utc { get; set; }
        public bool scheduled_start_time_utcSpecified { get; set; }
        public DateTime end_time { get; set; }
        public bool end_timeSpecified { get; set; }
        public int status { get; set; }
        public bool statusSpecified { get; set; }
        //public object names { get; set; }
        public List<States> state { get; set; }
        //public object current_state { get; set; }
        public int attendance { get; set; }
        public bool attendanceSpecified { get; set; }
        public string sport_id { get; set; }
        public string venue_id { get; set; }
        //public object start_venue_id { get; set; }
        //public object finish_venue_id { get; set; }
        public string phase_id { get; set; }
        public List<string> sports_organization_ids { get; set; }
        public List<string> parent_sports_event_ids { get; set; }
        [NotMapped]
        public WeatherConditions weather_conditions { get; set; }
        //public object event_attributes { get; set; }
        public string sports_discipline_id { get; set; }
        public string sports_gender_id { get; set; }
        public int sibling_order { get; set; }
        public bool sibling_orderSpecified { get; set; }
        public int schedule_status { get; set; }
        public bool schedule_statusSpecified { get; set; }
        public int result_status { get; set; }
        public bool result_statusSpecified { get; set; }
        public List<Property> properties { get; set; }
        public List<NavigationInfo> navigation_info { get; set; }
        public int event_type_detail { get; set; }
        public bool event_type_detailSpecified { get; set; }
        public string direct_parent_sports_event_id { get; set; }
        public string home_participant_id { get; set; }
        public string away_participant_id { get; set; }
        public int participant_type { get; set; }
        public bool participant_typeSpecified { get; set; }
        [NotMapped]
        public DateAndTimeInfo date_and_time_info { get; set; }
        public string translation_reference_id { get; set; }


        //public object sports { get; set; }

        //public object sports_organizations { get; set; }

        //public object venues { get; set; }
        //[JsonIgnore]
        //public object child_sports_events { get; set; }
        [NotMapped]

        public List<RelatedSportsEvent> related_sports_events { get; set; }
        [NotMapped]
        public Meta meta { get; set; }
        //public object xids { get; set; }
    }

}
