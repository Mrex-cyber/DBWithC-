using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBTraining.Migrations
{
    public partial class HaveJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HaveJob",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HaveJob",
                table: "Users");
        }
    }
}
