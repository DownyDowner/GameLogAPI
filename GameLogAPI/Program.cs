using FastEndpoints;
using FastEndpoints.Swagger;
using GameLogAPI.src.Data;
using GameLogAPI.src.Repositories;
using GameLogAPI.src.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services
   .AddFastEndpoints()
   .SwaggerDocument();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<GameService>();

builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<PlatformService>();

var app = builder.Build();
app.UseFastEndpoints()
   .UseSwaggerGen();
app.Run();

app.Run();
