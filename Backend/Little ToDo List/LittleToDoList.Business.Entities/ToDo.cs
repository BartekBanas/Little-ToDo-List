using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LittleToDoList.Business.Abstractions;

namespace LittleToDoList.Business.Entities;

public class ToDo : Entity
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreationDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; }
    
    [ForeignKey(nameof(User))]
    public Guid AssignedUserId  { get; set; }

    private ToDo()
    {
    }

    private ToDo(string name, string? description, Guid assignedUserId)
    {
        Name = name;
        Description = description;
        CreationDate = DateTime.Now;
        AssignedUserId = assignedUserId;
    }

    public static ToDo CreateInstance(string name, string? description, Guid assignedUserId)
    {
        return new ToDo(name, description, assignedUserId);
    }
}