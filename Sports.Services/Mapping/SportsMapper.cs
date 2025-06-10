using Sports.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Services.Mapping
{
    public static class SportsMapper
    {
        public static List<Sports.Models.Sport> SportDTOToSport(List<Sports.Infrastructure.DTOs.Sport> sports)
        {
            if (sports == null)
            {
                return null;
            }
            return sports.Select(sport => new Sports.Models.Sport
            {
                id = sport.id,
                description = sport.description,
                type = sport.type,
                start_date_local = sport.start_date_local,
                start_date_localSpecified = sport.start_date_localSpecified,
                scheduled_start_time_utc = sport.scheduled_start_time_utc,
                scheduled_start_time_utcSpecified = sport.scheduled_start_time_utcSpecified,
                end_time = sport.end_time,
                end_timeSpecified = sport.end_timeSpecified,
                status = sport.status,
                statusSpecified = sport.statusSpecified,
                attendance = sport.attendance,
                attendanceSpecified = sport.attendanceSpecified,
                sport_id = sport.sport_id,
                venue_id = sport.venue_id,
                phase_id = sport.phase_id,
                date_and_time_info = sport.date_and_time_info != null ? new Sports.Models.DateAndTimeInfo
                {

                    scheduled_start_time_utc = sport.date_and_time_info.scheduled_start_time_utc,
                    scheduled_start_time_utcSpecified = sport.date_and_time_info.scheduled_start_time_utcSpecified,
                    scheduled_end_time_utc = sport.date_and_time_info.scheduled_end_time_utc,
                    scheduled_end_time_utcSpecified = sport.date_and_time_info.scheduled_end_time_utcSpecified,
                    actual_start_time_utc = sport.date_and_time_info.actual_start_time_utc,
                    actual_start_time_utcSpecified = sport.date_and_time_info.actual_start_time_utcSpecified,
                    actual_end_time_utc = sport.date_and_time_info.actual_end_time_utc,
                    actual_end_time_utcSpecified = sport.date_and_time_info.actual_end_time_utcSpecified,
                    start_date_local = sport.date_and_time_info.start_date_local,
                    start_date_localSpecified = sport.date_and_time_info.start_date_localSpecified,
                    end_date_local = sport.date_and_time_info.end_date_local,
                    end_date_localSpecified = sport.date_and_time_info.end_date_localSpecified
                } : null,

                sports_organization_ids = sport.sports_organization_ids?.ToList(),
                parent_sports_event_ids = sport.parent_sports_event_ids?.ToList(),
                // weather_conditions = sport.weather_conditions, // Uncomment if mapping is needed and types match
                sports_discipline_id = sport.sports_discipline_id,
                sports_gender_id = sport.sports_gender_id
                // Continue mapping other properties as needed
            }).ToList();


        }
    }
}