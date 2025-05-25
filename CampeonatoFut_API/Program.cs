using System.Text.Json.Serialization;
using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut.Shared.Data.Models;
using CampeonatoFut.Shared.Models;
using CampeonatoFut_API.EndPoints;
using CampeonatoFut_Console;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<CampeonatoFutContext>();
builder.Services.AddTransient<DAL<Team>>();
builder.Services.AddTransient<DAL<Player>>();
builder.Services.AddTransient<DAL<Stadium>>();
builder.Services.AddTransient<DAL<Uniform>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityApiEndpoints<AccessUser>().AddEntityFrameworkStores<CampeonatoFutContext>();
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseAuthorization();

app.MapGet("/", () => Results.Redirect("/swagger"));
app.MapGroup("auth").MapIdentityApi<AccessUser>().WithTags("Authorization");
app.MapPost("auth/logout", async ([FromServices] SignInManager<AccessUser> signInManager) =>
{
    await signInManager.SignOutAsync();
    return Results.Ok();
}
).RequireAuthorization().WithTags("Authorization");


app.AddEndPointsTeam();
app.AddEndPointsPlayer();
app.AddEndPointsStadium();
app.AddEndPointsUniform();

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
