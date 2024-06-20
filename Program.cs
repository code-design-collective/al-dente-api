using Microsoft.EntityFrameworkCore;

using AlDenteAPI.Database
;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// other services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.MapGet("/test", () =>
{
    return new { text = "Hello World From Al Dente API" };
})
.WithName("GetTest")
.WithOpenApi();

// app.MapGet("/testdb", async () =>
// {
//     using var scope = app.Services.CreateScope();
//     var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//     var recipeCount = await db.Recipes.CountAsync();
//     return new { RecipeCount = recipeCount };
// })
// .WithName("GetTestDB")
// .WithOpenApi();

app.Run();
