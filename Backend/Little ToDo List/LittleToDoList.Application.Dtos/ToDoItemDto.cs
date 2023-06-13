namespace LittleToDoList.Application.Dto;

public class ToDoItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; }
    public Guid AssignedUserId  { get; set; }

    public ToDoItemDto(int id, string name, DateTime creationDate, Guid assignedUserId)
    {
        Id = id;
        Name = name;
        CreationDate = creationDate;
        AssignedUserId = assignedUserId;
    }
}