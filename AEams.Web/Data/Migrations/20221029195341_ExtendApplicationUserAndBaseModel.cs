using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEams.Web.Data.Migrations
{
    public partial class ExtendApplicationUserAndBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Schedules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "Schedules",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);

       

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: true);


            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedById",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_CreatedById",
                table: "Schedules",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_LastUpdatedById",
                table: "Schedules",
                column: "LastUpdatedById");
    


            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AspNetUsers_CreatedById",
                table: "Schedules",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_AspNetUsers_LastUpdatedById",
                table: "Schedules",
                column: "LastUpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AspNetUsers_CreatedById",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_AspNetUsers_LastUpdatedById",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_CreatedById",
                table: "Schedules");

            migrationBuilder.DropIndex(
                name: "IX_Schedules_LastUpdatedById",
                table: "Schedules");


            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Departments");

         

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "Departments");



            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedById",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "AspNetUsers");
        }
    }
}
