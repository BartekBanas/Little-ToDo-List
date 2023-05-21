using LittleToDoList.Business.Abstractions;

namespace LittleToDoList.Business.Entities;

public class TaskItem : Entity
{
    public int Id { get; set; }
    
    public string Name { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    
    public DateTime? CompletionDate { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsDone { get; set; }

    private TaskItem()
    {
    }

    private TaskItem(string name, string? description)
    {
        Name = name;
        Description = description;
        CreationDate = DateTime.Now;
    }

    public static TaskItem CreateInstance(string name, string? description)
    {
        return new TaskItem(name, description);
    }
}