using AutoMapper;
using LittleToDoList.Application.Dto;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Services;

public interface IFriendshipService
{
    Task CreateFriendship(Guid firstAccountId, Guid secondAccountId);
    Task<IEnumerable<FriendshipDto>> GetFriendships(Guid accountId);
}

public class FriendshipService : IFriendshipService
{
    private readonly IRepository<UserFriendship> _friendshipRepository;
    private readonly IMapper _mapper;

    public FriendshipService(IRepository<UserFriendship> friendshipRepository, IMapper mapper)
    {
        _friendshipRepository = friendshipRepository;
        _mapper = mapper;
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

    public async Task<IEnumerable<FriendshipDto>> GetFriendships(Guid accountId)
    {
        var contacts = await _friendshipRepository
            .GetAsync(x => x.FirstUserId == accountId || x.SecondUserId == accountId);

        var dtos = _mapper.Map<IEnumerable<FriendshipDto>>(contacts);
        
        return dtos;
    }
}