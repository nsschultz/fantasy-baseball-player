using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyBaseball.PlayerService.Database.Migrations
{
    /// <inheritdoc />
    public partial class NewBhqFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DraftedPercentage",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "HighestPick",
                table: "Players",
                newName: "MlbAmId");

            migrationBuilder.RenameColumn(
                name: "DraftRank",
                table: "Players",
                newName: "AverageDraftPickMin");

            migrationBuilder.AlterColumn<double>(
                name: "AverageDraftPick",
                table: "Players",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "AverageDraftPickMax",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageDraftPickMax",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "MlbAmId",
                table: "Players",
                newName: "HighestPick");

            migrationBuilder.RenameColumn(
                name: "AverageDraftPickMin",
                table: "Players",
                newName: "DraftRank");

            migrationBuilder.AlterColumn<int>(
                name: "AverageDraftPick",
                table: "Players",
                type: "integer",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<double>(
                name: "DraftedPercentage",
                table: "Players",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
