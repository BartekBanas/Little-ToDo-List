using LittleToDoList.Api;
using Microsoft.EntityFrameworkCore;
using LittleToDoList.Infrastructure;
using LittleToDoList.Api.Controllers;
using LittleToDoList.Application.Services;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;
using LittleToDoList.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ============== CONFIG ==============
var configuration = builder.Configuration;

// ============= SERVICES =============
var services = builder.Services;

services.AddControllers();
services.AddControllers().AddApplicationPart(typeof(ToDoController).Assembly);
services.AddControllers().AddApplicationPart(typeof(UserController).Assembly);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContext<LittleTodoListDbContext>(contextOptionsBuilder =>
    contextOptionsBuilder.UseMySql(
        configuration.GetConnectionString("LittleTodoListDatabaseConnectionString"),
        new MySqlServerVersion(new Version(8, 0, 28)),
        optionsBuilder =>
        {
            optionsBuilder.MigrationsAssembly("LittleToDoList.Api");
        } 
    ));

services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

services.AddScoped<IRepository<ToDo>,     Repository<ToDo,  LittleTodoListDbContext>>();
services.AddScoped<IRepository<User>,     Repository<User,  LittleTodoListDbContext>>();
services.AddScoped<IRepository<UserFriendship>, Repository<UserFriendship, LittleTodoListDbContext>>();

services.AddScoped<IToDoItemService, ToDoItemService>();
services.AddScoped<IUserService, UserService>();

services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<LittleToDoList.Business.DomainEventHandlers.AssemblyMarker>();
});

// ============= RUN =============
var app = builder.Build();

app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyAPI");
        c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();