namespace LittleToDoList.Application.Dto;

public class UserUpdate
{
    public string Name { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
}