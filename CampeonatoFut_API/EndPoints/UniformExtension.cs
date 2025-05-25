using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut.Shared.Models;
using CampeonatoFut_API.Requests;
using CampeonatoFut_API.Responses;
using CampeonatoFut_Console;
using Microsoft.AspNetCore.Mvc;

namespace CampeonatoFut_API.EndPoints
{
    public static class UniformExtension
    {
        public static void AddEndPointsUniform(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("Uniform").RequireAuthorization().WithTags("Uniform");

            groupBuilder.MapGet("", ([FromServices] DAL<Uniform> dal) =>
            {
                var uniformList = dal.Read();
                if (uniformList is null)
                {
                    return Results.NotFound();
                }
                var uniformResponseList = EntityListToResponseList(uniformList);
                return Results.Ok(uniformResponseList);
            }
            );

            groupBuilder.MapPost("", ([FromServices] DAL<Uniform> dal, [FromBody] UniformRequest uniformRequest) =>
            {
                var uniform = new Uniform(uniformRequest.name);
                dal.Create(uniform);
                return Results.Ok();
            }
            );

            groupBuilder.MapPut("", ([FromServices] DAL<Uniform> dal, [FromBody] UniformEditRequest uniformEditRequest) =>
            {
                var uniformToEdit = dal.ReadBy(a => a.Id == uniformEditRequest.id);
                if (uniformToEdit is null)
                {
                    return Results.NotFound();
                }
                uniformToEdit.Name = uniformEditRequest.name;
                dal.Update(uniformToEdit);
                return Results.Created();
            }
            );

            groupBuilder.MapDelete("/{id}", ([FromServices] DAL<Uniform> dal, int id) =>
            {
                var uniform = dal.ReadBy(a => a.Id == id);
                if (uniform is null)
                {
                    return Results.NotFound();
                }
                dal.Delete(uniform);
                return Results.NoContent();
            }
            );

            groupBuilder.MapGet("/{id}", ([FromServices] DAL<Uniform> dal, int id) =>
            {
                var uniform = dal.ReadBy(a => a.Id == id);
                if (uniform is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(uniform));
            }
            );

        }

        private static ICollection<UniformResponse> EntityListToResponseList(IEnumerable<Uniform> uniformList)
        {
            return uniformList.Select(a => EntityToResponse(a)).ToList();
        }
        private static UniformResponse EntityToResponse(Uniform uniform)
        {
            return new UniformResponse(uniform.Id, uniform.Name, uniform.Team?.Id ?? 0, uniform.Team?.Name ?? "Sem time.");
        }
    }
}
