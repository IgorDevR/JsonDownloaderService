using DataAccess;
using DataAccess.Data;
using DataAccess.DbAccess;
using JsonDownloaderService.HttpClients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ISpaceXEventData, SpaceXEventData>();
builder.Services.AddSingleton<IHttpClientsFactory, SpaceXApiHttpClient>();
builder.Services.AddSingleton<HttpClient>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", (IEnumerable<EndpointDataSource> endpointSources) =>
{
    var sb = new StringBuilder();
    var endpoints = endpointSources.SelectMany(es => es.Endpoints);
    foreach (var endpoint in endpoints)
    {
        sb.AppendLine(endpoint.DisplayName);

        // получим конечную точку как RouteEndpoint
        if (endpoint is RouteEndpoint routeEndpoint)
        {
            sb.AppendLine(routeEndpoint.RoutePattern.RawText);
        }
    }
    return sb.ToString();
});

app.MapControllers();


app.Run();
