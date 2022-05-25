using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBTraining.Migrations
{
    public partial class FullName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "Age",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "FullAges",
                table: "Users",
                sql: "FullAges > 0 AND FullAges < 120");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "FullAges",
                table: "Users");

            migrationBuilder.AddCheckConstraint(
                name: "Age",
                table: "Users",
                sql: "Age > 0 AND Age < 120");
        }
    }
}
