using System.Text.Json.Serialization;
using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut_API.EndPoints;
using CampeonatoFut_Console;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<CampeonatoFutContext>();
builder.Services.AddTransient<DAL<Team>>();
builder.Services.AddTransient<DAL<Player>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.AddEndPointsTeam();
app.AddEndPointsPlayer();

app.UseSwagger();
app.UseSwaggerUI();


app.Run();
