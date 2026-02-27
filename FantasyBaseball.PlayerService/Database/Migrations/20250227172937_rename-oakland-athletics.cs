using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBaseball.PlayerService.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameOaklandAthletics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Code",
                keyValue: "OAK");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Code", "AlternativeCode", "City", "LeagueId", "Nickname" },
                values: new object[] { "ATH", null, "", "AL", "Athletics" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Code",
                keyValue: "ATH");

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Code", "AlternativeCode", "City", "LeagueId", "Nickname" },
                values: new object[] { "OAK", null, "Oakland", "AL", "Athletics" });
        }
    }
}
