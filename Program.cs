using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// other services

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.MapGet("/test", () =>
// {
//     return new { text = "Hello World From Al Dente API" };
// })
// .WithName("GetTest")
// .WithOpenApi();

app.MapGet("/testdb", () =>
{
    return new { text = "Hello World From /testdb endpoint" };
})
.WithName("GetTestDB")
.WithOpenApi();

app.Run();
