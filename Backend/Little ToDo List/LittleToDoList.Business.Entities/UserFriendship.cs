using LittleToDoList.Business.Abstractions;

namespace LittleToDoList.Business.Entities;

public class UserFriendship : Entity
{
    public Guid Id { get; set; }
    
    public Guid FirstUserId { get; set; }
    public virtual User FirstUser { get; set; } = null!;

    public Guid SecondUserId { get; set; }
    public virtual User SecondUser { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public UserFriendship(Guid firstUserId, Guid secondUserId)
    {
        FirstUserId = firstUserId;
        SecondUserId = secondUserId;
    }

    public static UserFriendship CreateInstance(Guid firstUserId, Guid secondUserId)
    {
        return new UserFriendship(firstUserId, secondUserId);
    }
}