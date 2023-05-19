using LittleToDoList.Api;
using Microsoft.EntityFrameworkCore;
using LittleToDoList.Infrastructure;
using LittleToDoList.Api.Controllers;
using LittleToDoList.Application.Services;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;
using LittleToDoList.Business.DomainEventHandlers;
using LittleToDoList.Infrastructure.Repositories;
using AutoMapper;
using MediatR;

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

services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

services.AddScoped<IRepository<TaskItem>,     Repository<TaskItem,  LittleTodoListDbContext>>();

services.AddScoped<IToDoItemService, ToDoItemService>();

services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<LittleToDoList.Business.DomainEventHandlers.AssemblyMarker>();
});
services.AddScoped<IMediator, Mediator>();

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