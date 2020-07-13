using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagerEntities.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "MaxPlayers", "MinAge", "MinPlayers", "Name" },
                values: new object[,]
                {
                    { 1, 5, 7, 2, "Game 1" },
                    { 2, 10, 15, 5, "Game 2" },
                    { 3, 4, 12, 1, "Game 3" },
                    { 4, 8, 12, 2, "Game 4" },
                    { 5, 6, 4, 2, "Game 5" },
                    { 6, 12, 16, 4, "Game 6" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
