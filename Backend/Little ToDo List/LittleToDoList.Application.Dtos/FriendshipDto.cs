namespace LittleToDoList.Application.Dto;

public class FriendshipDto
{
    public Guid FirstUserId { get; set; }

    public Guid SecondUserId { get; set; }
    
    public DateTime DateCreated { get; set; }
}