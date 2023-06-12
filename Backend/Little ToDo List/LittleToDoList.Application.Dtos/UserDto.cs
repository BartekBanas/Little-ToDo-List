namespace LittleToDoList.Application.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreationDate { get; set; }

    public UserDto()
    {
        
    }

    public UserDto(Guid id, string name, DateTime creationDate)
    {
        Id = id;
        Name = name;
        CreationDate = creationDate;
    }
}