using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Business.Events;

public class TodoCreated : DomainEvent<TaskItem>
{
    public TaskItem Entity { get; set; }
    
    public TodoCreated(TaskItem entity)
    {
        Entity = entity;
    }
}