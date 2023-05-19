using LittleToDoList.Infrastructure;
using Microsoft.EntityFrameworkCore;
using LittleToDoList.Api.Controllers;

var builder = WebApplication.CreateBuilder(args);

// ============== CONFIG ==============
var configuration = builder.Configuration;

// ============= SERVICES =============
var services = builder.Services;

services.AddControllers();
services.AddControllers().AddApplicationPart(typeof(ToDoTaskController).Assembly);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<LittleTodoListDbContext>(contextOptionsBuilder =>
    contextOptionsBuilder.UseMySql(
        configuration.GetConnectionString("LittleTodoListDatabaseConnectionString"),
        new MySqlServerVersion(new Version(8, 0, 28))
    ));

// ============= RUN =============
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();