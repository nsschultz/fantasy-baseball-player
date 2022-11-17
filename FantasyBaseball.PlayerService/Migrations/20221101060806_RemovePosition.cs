using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBaseball.PlayerService.Migrations
{
    public partial class RemovePosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "PlayerPosition_Position_FK",
                table: "PlayerPositionEntity");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropIndex(
                name: "IX_PlayerPositionEntity_PositionCode",
                table: "PlayerPositionEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    FullName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PlayerType = table.Column<int>(type: "integer", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Position_PK", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Code", "FullName", "PlayerType", "SortOrder" },
                values: new object[,]
                {
                    { "", "Unknown", 0, 2147483647 },
                    { "1B", "First Baseman", 1, 1 },
                    { "2B", "Second Baseman", 1, 2 },
                    { "3B", "Third Baseman", 1, 3 },
                    { "C", "Catcher", 1, 0 },
                    { "CF", "Center Feilder", 1, 7 },
                    { "DH", "Designated Hitter", 1, 10 },
                    { "IF", "Infielder", 1, 5 },
                    { "LF", "Left Fielder", 1, 6 },
                    { "OF", "Outfielder", 1, 9 },
                    { "P", "Pitcher", 1, 13 },
                    { "RF", "Right Fielder", 1, 8 },
                    { "RP", "Relief Pitcher", 1, 12 },
                    { "SP", "Starting Pitcher", 1, 11 },
                    { "SS", "Shortstop", 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPositionEntity_PositionCode",
                table: "PlayerPositionEntity",
                column: "PositionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_SortOrder",
                table: "Positions",
                column: "SortOrder",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "PlayerPosition_Position_FK",
                table: "PlayerPositionEntity",
                column: "PositionCode",
                principalTable: "Positions",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
