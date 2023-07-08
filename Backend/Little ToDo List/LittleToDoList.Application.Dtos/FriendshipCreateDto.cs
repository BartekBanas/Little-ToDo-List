namespace LittleToDoList.Application.Dto;

public class FriendshipCreateDto
{
    public Guid FirstUserId { get; set; }

    public Guid SecondUserId { get; set; }
}