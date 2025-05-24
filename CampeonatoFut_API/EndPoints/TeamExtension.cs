using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut.Shared.Models;
using CampeonatoFut_API.Requests;
using CampeonatoFut_API.Responses;
using CampeonatoFut_Console;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatoFut_API.EndPoints
{
    public static class TeamExtension
    {
        public static void AddEndPointsTeam(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Team").RequireAuthorization().WithTags("Team");

            groupBuilder.MapGet("", ([FromServices] DAL<Team> dal) =>
            {
                var teamList = dal.Read();
                if (teamList is null)
                {
                    return Results.NotFound();
                }
                var teamResponseList = EntityListToResponseList(teamList);
                return Results.Ok(teamResponseList);
            }
            );

            groupBuilder.MapPost("", ([FromServices] DAL<Team> dal, [FromServices] DAL<Stadium> dalStadium, [FromBody] TeamRequest teamRequest) =>
            {
                var team = new Team(teamRequest.name, teamRequest.coach)
                {
                    Stadiums = teamRequest.Stadiums is not null ? StadiumRequestConverter(teamRequest.Stadiums, dalStadium) : new List<Stadium>()
                };
                dal.Create(team);
                return Results.Ok();
            }
            );

            groupBuilder.MapPut("", ([FromServices] DAL<Team> dal, [FromBody] TeamEditRequest teamEditRequest) =>
            {
                var teamToEdit = dal.ReadBy(a => a.Id == teamEditRequest.id);
                if (teamToEdit is null)
                {
                    return Results.NotFound();
                }
                teamToEdit.Name = teamEditRequest.name;
                teamToEdit.Coach = teamEditRequest.coach;
                dal.Update(teamToEdit);
                return Results.Created();
            }
            );

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Team> dal, int id) =>
            {
                var team = dal.ReadBy(a => a.Id == id);
                if (team is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(team);
                return Results.NoContent();
            }
            );

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Team> dal, int id) =>
            {
                var team = dal.ReadBy(a => a.Id == id);
                if (team is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(team));
            }
            );

        }

        private static ICollection<TeamResponse> EntityListToResponseList(IEnumerable<Team> teamList)
        {
            return teamList.Select(a => EntityToResponse(a)).ToList();
        }
        private static TeamResponse EntityToResponse(Team team)
        {
            return new TeamResponse(team.Id, team.Name, team.Coach);
        }
        private static ICollection<Stadium> StadiumRequestConverter(ICollection<StadiumRequest> stadiumList, DAL<Stadium> dalStadium)
        {
            var stadList = new List<Stadium>();
            foreach (var item in stadiumList)
            {
                var stadium = RequestToEntity(item);
                var stadiumBuscado = dalStadium.ReadBy(I => I.Name.ToUpper().Equals(stadium.Name.ToUpper()));
                if (stadiumBuscado is not null)
                {
                    stadList.Add(stadiumBuscado);
                }
                else
                {
                    stadList.Add(stadium);
                }
            }
            //return stadiumList.Select(d => RequestToEntity(d)).ToList();
            return stadList;
        }
        private static Stadium RequestToEntity(StadiumRequest stadium)
        {
            return new Stadium() { Name = stadium.name };
        }

    }
}
