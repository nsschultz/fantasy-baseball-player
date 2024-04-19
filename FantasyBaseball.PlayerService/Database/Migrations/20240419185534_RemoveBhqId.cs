using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBaseball.PlayerService.Database.Migrations
{
    /// <inheritdoc />
    public partial class RemoveBhqId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "Player_Bhq_AK",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "BhqId",
                table: "Players");

            migrationBuilder.AddUniqueConstraint(
                name: "Player_MlbAmId_AK",
                table: "Players",
                columns: new[] { "MlbAmId", "Type" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "Player_MlbAmId_AK",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "BhqId",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "Player_Bhq_AK",
                table: "Players",
                columns: new[] { "BhqId", "Type" });
        }
    }
}
