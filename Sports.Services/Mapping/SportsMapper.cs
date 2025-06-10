using Humanizer;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                return null;

            var entities = sports.Select(sportDto =>
            {
                var sport = new Sports.Models.Sport
                {
                    id= sportDto.id,
                    description = sportDto.description,
                    type = sportDto.type,
                    start_date_local = sportDto.start_date_local,
                    start_date_localSpecified = sportDto.start_date_localSpecified,
                    scheduled_start_time_utc = sportDto.scheduled_start_time_utc,
                    scheduled_start_time_utcSpecified = sportDto.scheduled_start_time_utcSpecified,
                    end_time = sportDto.end_time,
                    end_timeSpecified = sportDto.end_timeSpecified,
                    status = sportDto.status,
                    statusSpecified = sportDto.statusSpecified,
                    attendance = sportDto.attendance,
                    attendanceSpecified = sportDto.attendanceSpecified,
                    sport_id = sportDto.sport_id,
                    venue_id = sportDto.venue_id,
                    phase_id = sportDto.phase_id,
                    sports_organization_ids = sportDto.sports_organization_ids?.ToList(),
                    parent_sports_event_ids = sportDto.parent_sports_event_ids?.ToList(),
                    sports_discipline_id = sportDto.sports_discipline_id,
                    sports_gender_id = sportDto.sports_gender_id
                };

                // Related sports events
                sport.related_sports_events = sportDto.related_sports_events?.Select(reDto =>
                {
                    var relatedEvent = new Sports.Models.RelatedSportsEvent
                    {
                        id = reDto.id,
                        type = reDto.type,
                        type_detail = reDto.type_detail,
                        depth = reDto.depth,
                        Sport = sport,  // <-- assign parent here!
                        navigation_info = reDto.navigation_info != null
                            ? new Sports.Models.NavigationInfo
                            {
                                has_standings = reDto.navigation_info.has_standings,
                                is_knockout = reDto.navigation_info.is_knockout,
                                Sport = sport // also assign Sport here
                            }
                            : null
                    };
                    return relatedEvent;
                }).ToList() ?? new List<Sports.Models.RelatedSportsEvent>();

                // States
                sport.States = sportDto.state?.Select(stateDto => new Sports.Models.State
                {
                    key = stateDto.key,
                    value = stateDto.value,
                    Sport = sport // assign parent Sport here
                }).ToList() ?? new List<Sports.Models.State>();

                // Weather conditions
                sport.weather_conditions = sportDto.weather_conditions != null ? new Sports.Models.WeatherConditions
                {
                    temperature_fahrenheit = sportDto.weather_conditions.temperature_fahrenheit,
                    temperature_fahrenheitSpecified = sportDto.weather_conditions.temperature_fahrenheitSpecified,
                    temperature_celsius = sportDto.weather_conditions.temperature_celsius,
                    temperature_celsiusSpecified = sportDto.weather_conditions.temperature_celsiusSpecified,
                    wind_speed_miles = sportDto.weather_conditions.wind_speed_miles,
                    wind_speed_milesSpecified = sportDto.weather_conditions.wind_speed_milesSpecified,
                    wind_speed_kilometers = sportDto.weather_conditions.wind_speed_kilometers,
                    wind_speed_kilometersSpecified = sportDto.weather_conditions.wind_speed_kilometersSpecified,
                    wind_direction = sportDto.weather_conditions.wind_direction,
                    wind_directionSpecified = sportDto.weather_conditions.wind_directionSpecified,
                    weather_type = sportDto.weather_conditions.weather_type,
                    weather_typeSpecified = sportDto.weather_conditions.weather_typeSpecified,
                    baseball_home_plate_wind_direction = sportDto.weather_conditions.baseball_home_plate_wind_direction,
                    baseball_home_plate_wind_directionSpecified = sportDto.weather_conditions.baseball_home_plate_wind_directionSpecified,
                    Sport = sport // assign parent Sport here
                } : null;

                return sport;
            }).ToList();

            return entities;
        }


    }
}