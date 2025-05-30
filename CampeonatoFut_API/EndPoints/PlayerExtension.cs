﻿using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut_API.Requests;
using CampeonatoFut_API.Responses;
using CampeonatoFut_Console;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatoFut_API.EndPoints
{
    public static class PlayerExtension
    {
        public static void AddEndPointsPlayer(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Player").RequireAuthorization().WithTags("Player");

            groupBuilder.MapGet("", ([FromServices] DAL<Player> dal) =>
            {
                var playerList = dal.Read();
                if (playerList is null)
                {
                    return Results.NotFound();
                }
                var playerResponseList = EntityListToResponseList(playerList);
                return Results.Ok(playerResponseList);
            }
            );

            groupBuilder.MapPost("", ([FromServices] DAL<Player> dal, [FromBody] PlayerRequest playerRequest) =>
            {
                var player = new Player(playerRequest.name);
                dal.Create(player);
                return Results.Ok();
            }
            );

            groupBuilder.MapPut("", ([FromServices] DAL<Player> dal, [FromBody] PlayerEditRequest playerEditRequest) =>
            {
                var playerToEdit = dal.ReadBy(a => a.Id == playerEditRequest.id);
                if (playerToEdit is null)
                {
                    return Results.NotFound();
                }
                playerToEdit.Name = playerEditRequest.name;
                dal.Update(playerToEdit);
                return Results.Created();
            }
            );

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Player> dal, int id) =>
            {
                var player = dal.ReadBy(a => a.Id == id);
                if (player is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(player);
                return Results.NoContent();
            }
            );

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Player> dal, int id) =>
            {
                var player = dal.ReadBy(a => a.Id == id);
                if (player is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(player));
            }
            );

        }

        private static ICollection<PlayerResponse> EntityListToResponseList(IEnumerable<Player> playerList)
        {
            return playerList.Select(a => EntityToResponse(a)).ToList();
        }
        private static PlayerResponse EntityToResponse(Player player)
        {
            return new PlayerResponse(player.Id, player.Name, player.Team?.Id?? 0, player.Team?.Name?? "Sem time.");
        }
    }
}
