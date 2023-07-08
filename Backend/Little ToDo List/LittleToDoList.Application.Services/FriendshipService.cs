using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Services;

public interface IFriendshipService
{
    Task CreateFriendship(Guid firstAccountId, Guid secondAccountId);
}

public class FriendshipService : IFriendshipService
{
    private readonly IRepository<UserFriendship> _friendshipRepository;

    public FriendshipService(IRepository<UserFriendship> friendshipRepository)
    {
        _friendshipRepository = friendshipRepository;
    }

    public async Task CreateFriendship(Guid firstAccountId, Guid secondAccountId)
    {
        var newFriendship = UserFriendship.CreateInstance(
            firstUserId: firstAccountId,
            secondUserId: secondAccountId
        );

        await _friendshipRepository.CreateOneAsync(newFriendship);

        await _friendshipRepository.SaveChangesAsync();
    }
}