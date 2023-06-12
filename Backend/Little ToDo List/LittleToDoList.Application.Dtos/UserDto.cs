namespace LittleToDoList.Application.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public DateTime CreationDate { get; set; }
}