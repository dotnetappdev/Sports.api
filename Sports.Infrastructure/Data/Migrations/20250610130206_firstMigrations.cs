using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sports.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateAndTimeInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    scheduled_start_time_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    scheduled_start_time_utcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    scheduled_end_time_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    scheduled_end_time_utcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    actual_start_time_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actual_start_time_utcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    actual_end_time_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    actual_end_time_utcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    start_date_local = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_date_localSpecified = table.Column<bool>(type: "bit", nullable: false),
                    end_date_local = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_date_localSpecified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    update_id = table.Column<long>(type: "bigint", nullable: true),
                    update_idSpecified = table.Column<bool>(type: "bit", nullable: false),
                    update_action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "NavigationInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    has_standings = table.Column<bool>(type: "bit", nullable: true),
                    is_knockout = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    key = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    start_date_local = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start_date_localSpecified = table.Column<bool>(type: "bit", nullable: false),
                    scheduled_start_time_utc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    scheduled_start_time_utcSpecified = table.Column<bool>(type: "bit", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end_timeSpecified = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    statusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    attendance = table.Column<int>(type: "int", nullable: false),
                    attendanceSpecified = table.Column<bool>(type: "bit", nullable: false),
                    sport_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    venue_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phase_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sports_organization_ids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parent_sports_event_ids = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sports_discipline_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sports_gender_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sibling_order = table.Column<int>(type: "int", nullable: false),
                    sibling_orderSpecified = table.Column<bool>(type: "bit", nullable: false),
                    schedule_status = table.Column<int>(type: "int", nullable: false),
                    schedule_statusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    result_status = table.Column<int>(type: "int", nullable: false),
                    result_statusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    event_type_detail = table.Column<int>(type: "int", nullable: false),
                    event_type_detailSpecified = table.Column<bool>(type: "bit", nullable: false),
                    direct_parent_sports_event_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    home_participant_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    away_participant_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    participant_type = table.Column<int>(type: "int", nullable: false),
                    participant_typeSpecified = table.Column<bool>(type: "bit", nullable: false),
                    translation_reference_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    temperature_fahrenheit = table.Column<int>(type: "int", nullable: false),
                    temperature_fahrenheitSpecified = table.Column<bool>(type: "bit", nullable: false),
                    temperature_celsius = table.Column<double>(type: "float", nullable: false),
                    temperature_celsiusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    wind_speed_miles = table.Column<int>(type: "int", nullable: false),
                    wind_speed_milesSpecified = table.Column<bool>(type: "bit", nullable: false),
                    wind_speed_kilometers = table.Column<double>(type: "float", nullable: false),
                    wind_speed_kilometersSpecified = table.Column<bool>(type: "bit", nullable: false),
                    wind_direction = table.Column<int>(type: "int", nullable: false),
                    wind_directionSpecified = table.Column<bool>(type: "bit", nullable: false),
                    weather_type = table.Column<int>(type: "int", nullable: false),
                    weather_typeSpecified = table.Column<bool>(type: "bit", nullable: false),
                    baseball_home_plate_wind_direction = table.Column<int>(type: "int", nullable: false),
                    baseball_home_plate_wind_directionSpecified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "RelatedSportsEvents",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    navigation_infoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_RelatedSportsEvents_NavigationInfos_navigation_infoId",
                        column: x => x.navigation_infoId,
                        principalTable: "NavigationInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RelatedSportsEvents_navigation_infoId",
                table: "RelatedSportsEvents",
                column: "navigation_infoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateAndTimeInfo");

            migrationBuilder.DropTable(
                name: "Metas");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "RelatedSportsEvents");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "WeatherConditions");

            migrationBuilder.DropTable(
                name: "NavigationInfos");
        }
    }
}
