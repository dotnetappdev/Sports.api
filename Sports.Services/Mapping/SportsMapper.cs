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
            {
                return null;
            }

            var entity = sports.Select(sport => new Sports.Models.Sport
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

                sports_organization_ids = sport.sports_organization_ids?.ToList(),
                parent_sports_event_ids = sport.parent_sports_event_ids?.ToList(),
                sports_discipline_id = sport.sports_discipline_id,
                sports_gender_id = sport.sports_gender_id,
                // FIX: Map DTO states to model States list
                States = sport.state != null
    ? sport.state.Select(s => new Sports.Models.State
    {
        SportId = sport.id, // Assuming SportId is the same as sport.id
        key = s.key,
        value = s.value
        // Map other properties if needed
    }).ToList()
    : new List<Sports.Models.State>(),
                // ...existing code...
                // ...existing code...
            }).ToList();
            return entity;
        }
    }
}