using FastEndpoints;
using FastEndpoints.Swagger;
using GameLogAPI.src.Data;
using GameLogAPI.src.Features.Games;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddFastEndpoints()
    .AddSwaggerDocument();

builder.Services.AddScoped<GameService>();

var app = builder.Build();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();
