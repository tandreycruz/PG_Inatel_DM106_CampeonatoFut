using System.Text.Json.Serialization;
using CampeonatoFut.Shared.Data.BD;
using CampeonatoFut_Console;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/", () =>
{
    var dal = new DAL<Team>();
    return dal.Read();
}
);


app.Run();
