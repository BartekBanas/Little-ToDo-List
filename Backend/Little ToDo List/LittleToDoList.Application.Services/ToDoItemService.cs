using AutoMapper;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Services;

public class ToDoItemService
{
    private readonly IRepository<TaskItem> _taskRepository;
    private readonly IMapper _mapper;

    public ToDoItemService(IRepository<TaskItem> taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    
    public async Task<TaskItem> GetTaskAsync(int taskId)
    {
        var account = await _taskRepository.GetOneAsync(taskId);
        
        var dto = _mapper.Map<TaskItem>(account);
        
        return dto;
    }
}