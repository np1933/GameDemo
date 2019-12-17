using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameDemo.Migrations
{
    public partial class resultTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultId = table.Column<Guid>(nullable: false),
                    Player1Move = table.Column<string>(nullable: true),
                    Player2Move = table.Column<string>(nullable: true),
                    CurrentTurn = table.Column<int>(nullable: false),
                    GameResult = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ResultId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");
        }
    }
}
