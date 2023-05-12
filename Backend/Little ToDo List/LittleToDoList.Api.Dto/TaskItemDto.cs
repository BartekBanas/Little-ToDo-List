namespace LittleToDoList.Api.Dto;

public class TaskItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; }

    public TaskItemDto(int id, string name, DateTime creationDate)
    {
        Id = id;
        Name = name;
        CreationDate = creationDate;
    }
}