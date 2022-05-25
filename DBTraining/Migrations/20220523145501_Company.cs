using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBTraining.Migrations
{
    public partial class Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 6);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "FirstName", "FullAges", "HaveJob", "LastName" },
                values: new object[] { 1, "Genry", 18, false, "Gustav" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "FirstName", "FullAges", "HaveJob", "LastName" },
                values: new object[] { 2, "Bob", 37, false, "Vatson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "FirstName", "FullAges", "HaveJob", "LastName" },
                values: new object[] { 3, "Nick", 25, false, "Nelson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "FirstName", "FullAges", "HaveJob", "LastName" },
                values: new object[] { 4, "Genry", 18, false, "Gustav" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "FirstName", "FullAges", "HaveJob", "LastName" },
                values: new object[] { 5, "Bob", 37, false, "Vatson" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "FirstName", "FullAges", "HaveJob", "LastName" },
                values: new object[] { 6, "Nick", 25, false, "Nelson" });
        }
    }
}
