namespace LittleToDoList.Application.Dto;

public class TaskUpdateDto
{
    public string? Name { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Description { get; set; }
    public bool? IsDone { get; set; }
    
    public TaskUpdateDto(string? name, DateTime? completionDate, string? description, bool? isDone)
    {
        Name = name;
        CompletionDate = completionDate;
        Description = description;
        IsDone = isDone;
    }
}