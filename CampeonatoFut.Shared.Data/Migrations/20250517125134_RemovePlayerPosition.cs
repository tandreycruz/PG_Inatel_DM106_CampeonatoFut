using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampeonatoFut.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePlayerPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Player");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Player",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
