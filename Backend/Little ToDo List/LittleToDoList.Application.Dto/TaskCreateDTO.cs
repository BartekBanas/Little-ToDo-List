namespace LittleToDoList.Application.Dto;

public class TaskCreateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public TaskCreateDto(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public TaskCreateDto(int id, string name, string? description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}