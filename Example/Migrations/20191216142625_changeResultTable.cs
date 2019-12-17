using Microsoft.EntityFrameworkCore.Migrations;

namespace GameDemo.Migrations
{
    public partial class changeResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Player2Move",
                table: "Results",
                newName: "PlayerName");

            migrationBuilder.RenameColumn(
                name: "Player1Move",
                table: "Results",
                newName: "PlayerMove");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayerName",
                table: "Results",
                newName: "Player2Move");

            migrationBuilder.RenameColumn(
                name: "PlayerMove",
                table: "Results",
                newName: "Player1Move");
        }
    }
}
