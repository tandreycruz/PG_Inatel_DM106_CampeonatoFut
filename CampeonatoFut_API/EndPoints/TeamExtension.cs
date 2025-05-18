using CampeonatoFut.Shared.Data.BD;
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
            app.MapGet("/Team", ([FromServices] DAL<Team> dal) =>
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

            app.MapPost("/Team", ([FromServices] DAL<Team> dal, [FromBody] TeamRequest teamRequest) =>
            {
                var team = new Team(teamRequest.name, teamRequest.coach);
                dal.Create(team);
                return Results.Ok();
            }
            );

            app.MapPut("/Team", ([FromServices] DAL<Team> dal, [FromBody] TeamEditRequest teamEditRequest) =>
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

            app.MapDelete("/Team/{id}", ([FromServices] DAL<Team> dal, int id) =>
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

            app.MapGet("/Team{id}", ([FromServices] DAL<Team> dal, int id) =>
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

    }
}
