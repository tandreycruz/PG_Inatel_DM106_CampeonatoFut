using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut.Shared.Models;
using CampeonatoFut_API.Requests;
using CampeonatoFut_API.Responses;
using CampeonatoFut_Console;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatoFut_API.EndPoints
{
    public static class StadiumExtension
    {
        public static void AddEndPointsStadium(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Stadium").RequireAuthorization().WithTags("Stadium");

            groupBuilder.MapGet("", ([FromServices] DAL<Stadium> dal) =>
            {
                var stadiumList = dal.Read();
                if (stadiumList is null)
                {
                    return Results.NotFound();
                }
                var stadiumResponseList = EntityListToResponseList(stadiumList);
                return Results.Ok(stadiumResponseList);
            }
            );

            groupBuilder.MapPost("", ([FromServices] DAL<Stadium> dal, [FromBody] StadiumRequest stadiumRequest) =>
            {
                dal.Create(RequestToEntity(stadiumRequest));
                return Results.Created();
            }
            );            

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Stadium> dal, int id) =>
            {
                var stadium = dal.ReadBy(a => a.Id == id);
                if (stadium is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(stadium);
                return Results.NoContent();
            }
            );

            // CONSULTAR TIMES A PARTIR DE UM (ID) ESTADIO
            groupBuilder.MapGet("/Teams", ([FromServices] DAL<Stadium> dal) =>
            {
                var stadiums = dal.ReadAll(s => true)
                                  .Select(s => new
                                  {
                                      Stadium = EntityToResponse(s),                                      
                                      Teams = s.Team.Any() ? s.Team.Select(t => EntityToResponse(t)).Cast<object>().ToList() : new List<object> { "Sem time" }
                                  });
                return Results.Ok(stadiums);
            });


        }

        private static ICollection<StadiumResponse> EntityListToResponseList(IEnumerable<Stadium> stadiumList)
        {
            return stadiumList.Select(a => EntityToResponse(a)).ToList();
        }
        private static StadiumResponse EntityToResponse(Stadium stadium)
        {
            return new StadiumResponse(stadium.Id, stadium.Name);
        }
        private static TeamResponse EntityToResponse(Team team)
        {
            return new TeamResponse(team.Id, team.Name, team.Coach);
        }
        private static Stadium RequestToEntity(StadiumRequest stadium)
        {
            return new Stadium() { Name = stadium.name };
        }
    }
}
