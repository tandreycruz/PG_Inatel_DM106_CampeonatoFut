﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CampeonatoFut.Shared.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelateTeamPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "Player",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamId",
                table: "Player",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player",
                column: "TeamId",
                principalTable: "Team",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "Player");
        }
    }
}
