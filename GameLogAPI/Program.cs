using FastEndpoints;
using GameLogAPI.src.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddFastEndpoints();

var app = builder.Build();
app.UseFastEndpoints();

app.Run();
