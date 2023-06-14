namespace LittleToDoList.Application.Dto;

public class ToDoCreateDto
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid AssignedUserId  { get; set; }

    public ToDoCreateDto()
    {
    }

    public ToDoCreateDto(string name)
    {
        Name = name;
    }

    public ToDoCreateDto(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}