namespace LittleToDoList.Application.Dto;

public class UserUpdateDto
{
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
}