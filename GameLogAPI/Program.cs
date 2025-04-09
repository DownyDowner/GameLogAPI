using FastEndpoints;
using FastEndpoints.Swagger;
using GameLogAPI.src.Data;
using GameLogAPI.src.Features.Games;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services
   .AddFastEndpoints()
   .SwaggerDocument();

builder.Services.AddScoped<GameService>();

var app = builder.Build();
app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();

app.Run();
