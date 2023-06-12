using AutoMapper;
using LittleToDoList.Application.Dto;
using LittleToDoList.Application.Dto.Mapping;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Services;

public interface IUserService
{
    Task<UserDto> GetUserAsync(Guid userId);
    Task<ICollection<UserDto>> GetAllUsersAsync();
    Task CreateUser(UserCreateDto dto);
    Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto updateDto);
    Task DeleteUser(Guid userId);
}

public class UserService : IUserService
{
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public UserService(IRepository<User> userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> GetUserAsync(Guid userId)
    {
        var user = await _userRepository.GetOneRequiredAsync(userId);

        var dto = user.ToDto();

        return dto;
    }

    public async Task<ICollection<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();

        var dtos = _mapper.Map<ICollection<UserDto>>(users);

        return dtos;
    }

    public async Task CreateUser(UserCreateDto dto)
    {
        var newUser = dto.ToEntity();

        await _userRepository.CreateOneAsync(newUser);

        //newTodoTask.AddDomainEvent(new TodoCreated(newTodoTask));

        await _userRepository.SaveChangesAsync();
    }

    public async Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto updateDto)
    {
        var entity = await _userRepository.UpdateAsync(updateDto, id);

        var updatedDto = entity.ToDto();
        
        await _userRepository.SaveChangesAsync();
        
        return updatedDto;
    }

    public async Task DeleteUser(Guid userId)
    {
        await _userRepository.DeleteOneAsync(userId);

        await _userRepository.SaveChangesAsync();
    }
}