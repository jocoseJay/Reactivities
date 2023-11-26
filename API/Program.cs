using API.Extensions;
using Application.Core;
using Application.HobbyLists;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("addcors");
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    var dbContext = services.GetRequiredService<DataContext>();
    await dbContext.Database.MigrateAsync();
    await Seed.SeedData(dbContext);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<DataContext>>();
    logger.LogError(ex, "Error during migration");
}

app.Run();
