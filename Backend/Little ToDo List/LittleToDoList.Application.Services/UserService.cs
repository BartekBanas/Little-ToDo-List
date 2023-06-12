using AutoMapper;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Services;

public interface IUserService
{
}

public class UserService : IUserService
{
    private readonly IRepository<User> _taskRepository;
    private readonly IMapper _mapper;

    public UserService(IRepository<User> taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
}