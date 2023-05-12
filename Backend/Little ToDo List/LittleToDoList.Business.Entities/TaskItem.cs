using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LittleToDoList.Business.Abstractions;

namespace LittleToDoList.Business.Entities;

public class TaskItem : Entity
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(64)]
    public string Name { get; set; } = null!;
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreationDate { get; set; }
    
    public DateTime CompletionDate { get; set; }
    
    public string? Description { get; set; }
    
    public bool IsDone { get; set; }
}