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
    
    public async Task<TaskItem> GetTodoItemAsync(int todoItemId)
    {
        var taskItem = await _taskRepository.GetOneAsync(todoItemId);
        
        var dto = _mapper.Map<TaskItem>(taskItem);
        
        return dto;
    }
}