using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampeonatoFut.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlayerDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Player", new[] { "Name", "TeamId" }, new object[] { "Arrascaeta", 3 });
            migrationBuilder.InsertData("Player", new[] { "Name", "TeamId" }, new object[] { "Yuri Alberto", 1 });
            migrationBuilder.InsertData("Player", new[] { "Name", "TeamId" }, new object[] { "Jaderson", 2});
            migrationBuilder.InsertData("Player", new[] { "Name", "TeamId" }, new object[] { "Aguinaldo Seu Boneco", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
