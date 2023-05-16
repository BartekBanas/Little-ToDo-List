using LittleToDoList.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

services.AddDbContext<LittleTodoListDbContext>(contextOptionsBuilder =>
    contextOptionsBuilder.UseMySql(
        configuration.GetConnectionString("LittleTodoListDatabaseConnectionString"),
        new MySqlServerVersion(new Version(8, 0, 29))
    ));


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();