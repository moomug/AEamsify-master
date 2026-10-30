using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEams.Web.Data.Migrations
{
    public partial class AddScheduleAndScheduleWeekTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    StartOne = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndOne = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartTwo = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndtTwo = table.Column<TimeSpan>(type: "time", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleWeekOffs",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "int", nullable: false),
                    WeekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleWeekOffs", x => new { x.ScheduleId, x.WeekId });
                    table.ForeignKey(
                        name: "FK_ScheduleWeekOffs_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleWeekOffs_Weeks_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Weeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_DepartmentId",
                table: "Schedules",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_Title_DepartmentId",
                table: "Schedules",
                columns: new[] { "Title", "DepartmentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleWeekOffs_WeekId",
                table: "ScheduleWeekOffs",
                column: "WeekId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleWeekOffs");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
