using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBaseball.PlayerService.Database.Migrations
{
    public partial class RenameTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Player_MlbTeam_FK",
                table: "Players");

            migrationBuilder.DropTable(
                name: "MlbTeams");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    AlternativeCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    LeagueId = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    City = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Nickname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Team_PK", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Code", "AlternativeCode", "City", "LeagueId", "Nickname" },
                values: new object[,]
                {
                    { "", null, "Free Agent", "", "Free Agent" },
                    { "ARZ", "ARI", "Arizona", "NL", "Diamondbacks" },
                    { "ATL", null, "Atlanta", "NL", "Braves" },
                    { "BAL", null, "Baltimore", "AL", "Orioles" },
                    { "BOS", null, "Boston", "AL", "Red Sox" },
                    { "CHC", null, "Chicago", "NL", "Cubs" },
                    { "CIN", null, "Cincinnati", "NL", "Reds" },
                    { "CLE", null, "Cleveland", "AL", "Guardians" },
                    { "COL", null, "Colorado", "NL", "Rockies" },
                    { "CWS", "CHW", "Chicago", "AL", "White Sox" },
                    { "DET", null, "Detriot", "AL", "Tigers" },
                    { "HOU", null, "Houston", "AL", "Astros" },
                    { "KC", null, "Kansas City", "AL", "Royals" },
                    { "LAA", null, "Los Angeles", "AL", "Angels" },
                    { "LAD", "LA", "Los Angeles", "NL", "Dodgers" },
                    { "MIA", null, "Miami", "NL", "Marlins" },
                    { "MIL", null, "Milwaukee", "NL", "Brewers" },
                    { "MIN", null, "Minnesota", "AL", "Twins" },
                    { "NYM", null, "New York", "NL", "Mets" },
                    { "NYY", null, "New York", "AL", "Yankees" },
                    { "OAK", null, "Oakland", "AL", "Athletics" },
                    { "PHI", null, "Philadelphia", "NL", "Phillies" },
                    { "PIT", null, "Pittsburgh", "NL", "Pirates" },
                    { "SD", null, "San Diego", "NL", "Padres" },
                    { "SEA", null, "Seattle", "AL", "Mariners" },
                    { "SF", null, "San Francisco", "NL", "Giants" },
                    { "STL", null, "St. Louis", "NL", "Cardinals" },
                    { "TB", "TAM", "Tampa Bay", "AL", "Rays" },
                    { "TEX", null, "Texas", "AL", "Rangers" },
                    { "TOR", null, "Toronto", "AL", "Blue Jays" },
                    { "WAS", null, "Washington", "NL", "Nationals" }
                });

            migrationBuilder.AddForeignKey(
                name: "Player_Team_FK",
                table: "Players",
                column: "Team",
                principalTable: "Teams",
                principalColumn: "Code");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Player_Team_FK",
                table: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.CreateTable(
                name: "MlbTeams",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    AlternativeCode = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: true),
                    City = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    MlbLeagueId = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    Nickname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("MlbTeam_PK", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "MlbTeams",
                columns: new[] { "Code", "AlternativeCode", "City", "MlbLeagueId", "Nickname" },
                values: new object[,]
                {
                    { "", null, "Free Agent", "", "Free Agent" },
                    { "ARZ", "ARI", "Arizona", "NL", "Diamondbacks" },
                    { "ATL", null, "Atlanta", "NL", "Braves" },
                    { "BAL", null, "Baltimore", "AL", "Orioles" },
                    { "BOS", null, "Boston", "AL", "Red Sox" },
                    { "CHC", null, "Chicago", "NL", "Cubs" },
                    { "CIN", null, "Cincinnati", "NL", "Reds" },
                    { "CLE", null, "Cleveland", "AL", "Indians" },
                    { "COL", null, "Colorado", "NL", "Rockies" },
                    { "CWS", "CHW", "Chicago", "AL", "White Sox" },
                    { "DET", null, "Detriot", "AL", "Tigers" },
                    { "HOU", null, "Houston", "AL", "Astros" },
                    { "KC", null, "Kansas City", "AL", "Royals" },
                    { "LAA", null, "Los Angeles", "AL", "Angels" },
                    { "LAD", "LA", "Los Angeles", "NL", "Dodgers" },
                    { "MIA", null, "Miami", "NL", "Marlins" },
                    { "MIL", null, "Milwaukee", "NL", "Brewers" },
                    { "MIN", null, "Minnesota", "AL", "Twins" },
                    { "NYM", null, "New York", "NL", "Mets" },
                    { "NYY", null, "New York", "AL", "Yankees" },
                    { "OAK", null, "Oakland", "AL", "Athletics" },
                    { "PHI", null, "Philadelphia", "NL", "Phillies" },
                    { "PIT", null, "Pittsburgh", "NL", "Pirates" },
                    { "SD", null, "San Diego", "NL", "Padres" },
                    { "SEA", null, "Seattle", "AL", "Mariners" },
                    { "SF", null, "San Francisco", "NL", "Giants" },
                    { "STL", null, "St. Louis", "NL", "Cardinals" },
                    { "TB", "TAM", "Tampa Bay", "AL", "Rays" },
                    { "TEX", null, "Texas", "AL", "Rangers" },
                    { "TOR", null, "Toronto", "AL", "Blue Jays" },
                    { "WAS", null, "Washington", "NL", "Nationals" }
                });

            migrationBuilder.AddForeignKey(
                name: "Player_MlbTeam_FK",
                table: "Players",
                column: "Team",
                principalTable: "MlbTeams",
                principalColumn: "Code");
        }
    }
}
