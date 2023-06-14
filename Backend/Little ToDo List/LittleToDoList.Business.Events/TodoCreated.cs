using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Business.Events;

public class TodoCreated : DomainEvent<ToDo>
{
    public ToDo Entity { get; set; }
    
    public TodoCreated(ToDo entity)
    {
        Entity = entity;
    }
}