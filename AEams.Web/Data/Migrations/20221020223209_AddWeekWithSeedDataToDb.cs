using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AEams.Web.Data.Migrations
{
    public partial class AddWeekWithSeedDataToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Weeks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameEn = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NameAr = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weeks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Weeks",
                columns: new[] { "Id", "NameAr", "NameEn" },
                values: new object[,]
                {
                    { 1, "الأحد", "Sunday" },
                    { 2, "الإثنين", "Monday" },
                    { 3, "الثلاثاء", "Tuesday" },
                    { 4, "الاربعاء", "Wednesday" },
                    { 5, "الخميس", "Thursday" },
                    { 6, "الجمعة", "Friday" },
                    { 7, "السبت", "Saturday" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Name",
                table: "Departments",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weeks");

            migrationBuilder.DropIndex(
                name: "IX_Departments_Name",
                table: "Departments");
        }
    }
}
