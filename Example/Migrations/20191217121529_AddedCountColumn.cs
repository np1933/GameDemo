using Microsoft.EntityFrameworkCore.Migrations;

namespace GameDemo.Migrations
{
    public partial class AddedCountColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Results",
                newName: "WinCount");

            migrationBuilder.AddColumn<int>(
                name: "DrawCount",
                table: "Results",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrawCount",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "WinCount",
                table: "Results",
                newName: "Count");
        }
    }
}
