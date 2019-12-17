using Microsoft.EntityFrameworkCore.Migrations;

namespace GameDemo.Migrations
{
    public partial class ChangedResultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GameResult",
                table: "Results",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Results",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player1Move",
                table: "Results",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Player2Move",
                table: "Results",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Player1Move",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "Player2Move",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "GameResult",
                table: "Results",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
