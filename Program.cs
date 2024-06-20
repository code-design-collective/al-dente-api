using Microsoft.EntityFrameworkCore;
using AlDenteAPI.Database;
using AlDenteAPI.Endpoints;
using AlDenteAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add HTTPS configuration
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(8001, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Cache"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.MapRecipeEndpoints();

app.MapGet("/test", () =>
{
    return new { text = "Hello World From Al Dente API" };
});

app.Run();