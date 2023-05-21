namespace LittleToDoList.Application.Dto;

public class TaskCreateDto
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public TaskCreateDto()
    {
    }

    public TaskCreateDto(string name)
    {
        Name = name;
    }

    public TaskCreateDto(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}