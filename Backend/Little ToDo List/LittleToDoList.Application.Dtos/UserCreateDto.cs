namespace LittleToDoList.Application.Dto;

public class UserCreateDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
}