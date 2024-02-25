using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBaseball.PlayerService.Database.Migrations
{
    public partial class TeamAltCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Code",
                keyValue: "CHC",
                column: "AlternativeCode",
                value: "CHI");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Code",
                keyValue: "WAS",
                column: "AlternativeCode",
                value: "WSH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Code",
                keyValue: "CHC",
                column: "AlternativeCode",
                value: null);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Code",
                keyValue: "WAS",
                column: "AlternativeCode",
                value: null);
        }
    }
}
