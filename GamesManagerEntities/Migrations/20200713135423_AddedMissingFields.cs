using Microsoft.EntityFrameworkCore.Migrations;

namespace GameManagerEntities.Migrations
{
    public partial class AddedMissingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameViewHistory_Games_GameId",
                table: "GameViewHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameViewHistory",
                table: "GameViewHistory");

            migrationBuilder.RenameTable(
                name: "GameViewHistory",
                newName: "GameViewHistories");

            migrationBuilder.RenameIndex(
                name: "IX_GameViewHistory_GameId",
                table: "GameViewHistories",
                newName: "IX_GameViewHistories_GameId");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "GameViewHistories",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameViewHistories",
                table: "GameViewHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameViewHistories_Games_GameId",
                table: "GameViewHistories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameViewHistories_Games_GameId",
                table: "GameViewHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameViewHistories",
                table: "GameViewHistories");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "GameViewHistories");

            migrationBuilder.RenameTable(
                name: "GameViewHistories",
                newName: "GameViewHistory");

            migrationBuilder.RenameIndex(
                name: "IX_GameViewHistories_GameId",
                table: "GameViewHistory",
                newName: "IX_GameViewHistory_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameViewHistory",
                table: "GameViewHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GameViewHistory_Games_GameId",
                table: "GameViewHistory",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
