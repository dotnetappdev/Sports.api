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
                name: "Sports",
                columns: table => new
                {
                    SportsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    sport_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    venue_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phase_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sports_organization_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent_sports_event_ids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sports_discipline_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sports_gender_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sibling_order = table.Column<int>(type: "int", nullable: true),
                    sibling_orderSpecified = table.Column<bool>(type: "bit", nullable: false),
                    schedule_status = table.Column<int>(type: "int", nullable: true),
                    schedule_statusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    result_status = table.Column<int>(type: "int", nullable: false),
                    result_statusSpecified = table.Column<bool>(type: "bit", nullable: false),
                    event_type_detail = table.Column<int>(type: "int", nullable: false),
                    event_type_detailSpecified = table.Column<bool>(type: "bit", nullable: false),
                    direct_parent_sports_event_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    home_participant_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    away_participant_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    participant_type = table.Column<int>(type: "int", nullable: false),
                    participant_typeSpecified = table.Column<bool>(type: "bit", nullable: false),
                    translation_reference_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportsId);
                });

            migrationBuilder.CreateTable(
                name: "Metas",
                columns: table => new
                {
                    MetaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    update_id = table.Column<long>(type: "bigint", nullable: true),
                    update_idSpecified = table.Column<bool>(type: "bit", nullable: false),
                    update_action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metas", x => x.MetaId);
                    table.ForeignKey(
                        name: "FK_Metas_Sports_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sports",
                        principalColumn: "SportsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NavigationInfos",
                columns: table => new
                {
                    NavigationInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    has_standings = table.Column<bool>(type: "bit", nullable: true),
                    is_knockout = table.Column<bool>(type: "bit", nullable: true),
                    SportId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavigationInfos", x => x.NavigationInfoId);
                    table.ForeignKey(
                        name: "FK_NavigationInfos_Sports_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sports",
                        principalColumn: "SportsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Sports_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sports",
                        principalColumn: "SportsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    ValuesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.ValuesId);
                    table.ForeignKey(
                        name: "FK_Values_Sports_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sports",
                        principalColumn: "SportsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherConditions",
                columns: table => new
                {
                    WeatherConditionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    baseball_home_plate_wind_directionSpecified = table.Column<bool>(type: "bit", nullable: false),
                    SportId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherConditions", x => x.WeatherConditionsId);
                    table.ForeignKey(
                        name: "FK_WeatherConditions_Sports_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sports",
                        principalColumn: "SportsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedSportsEvents",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type_detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    depth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    navigation_infoNavigationInfoId = table.Column<int>(type: "int", nullable: false),
                    SportsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedSportsEvents", x => x.id);
                    table.ForeignKey(
                        name: "FK_RelatedSportsEvents_NavigationInfos_navigation_infoNavigationInfoId",
                        column: x => x.navigation_infoNavigationInfoId,
                        principalTable: "NavigationInfos",
                        principalColumn: "NavigationInfoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RelatedSportsEvents_Sports_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sports",
                        principalColumn: "SportsId");
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    key = table.Column<int>(type: "int", nullable: false),
                    ValuesId = table.Column<int>(type: "int", nullable: true),
                    SportId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SportsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Sports_SportsId",
                        column: x => x.SportsId,
                        principalTable: "Sports",
                        principalColumn: "SportsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Values_ValuesId",
                        column: x => x.ValuesId,
                        principalTable: "Values",
                        principalColumn: "ValuesId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metas_SportsId",
                table: "Metas",
                column: "SportsId");

            migrationBuilder.CreateIndex(
                name: "IX_NavigationInfos_SportsId",
                table: "NavigationInfos",
                column: "SportsId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SportsId",
                table: "Properties",
                column: "SportsId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ValuesId",
                table: "Properties",
                column: "ValuesId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedSportsEvents_navigation_infoNavigationInfoId",
                table: "RelatedSportsEvents",
                column: "navigation_infoNavigationInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RelatedSportsEvents_SportsId",
                table: "RelatedSportsEvents",
                column: "SportsId");

            migrationBuilder.CreateIndex(
                name: "IX_States_SportsId",
                table: "States",
                column: "SportsId");

            migrationBuilder.CreateIndex(
                name: "IX_Values_SportsId",
                table: "Values",
                column: "SportsId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherConditions_SportsId",
                table: "WeatherConditions",
                column: "SportsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metas");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "RelatedSportsEvents");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "WeatherConditions");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "NavigationInfos");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
