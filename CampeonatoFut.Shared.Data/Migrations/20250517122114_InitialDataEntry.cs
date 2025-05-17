using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampeonatoFut.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Team", new[] { "Name", "Coach" }, new object[] { "Corinthians", "Dorival Junior" });
            migrationBuilder.InsertData("Team", new[] { "Name", "Coach" }, new object[] { "Remo", "Daniel Paulista" });
            migrationBuilder.InsertData("Team", new[] { "Name", "Coach" }, new object[] { "Flamengo", "Felipe Luis" });
            migrationBuilder.InsertData("Team", new[] { "Name", "Coach" }, new object[] { "Palmeiras", "Scolari" });
            migrationBuilder.InsertData("Team", new[] { "Name", "Coach" }, new object[] { "São Paulo", "Telê Santana" });
            migrationBuilder.InsertData("Team", new[] { "Name", "Coach" }, new object[] { "Internacional", "Roger" });
            migrationBuilder.InsertData("Team", new[] { "Name", "Coach" }, new object[] { "Paysandu", "Mucura" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Team");
        }
    }
}
