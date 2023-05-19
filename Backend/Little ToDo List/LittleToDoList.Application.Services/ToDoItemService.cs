using AutoMapper;
using LittleToDoList.Application.Dto;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Services;

public interface IToDoItemService
{
    Task<TaskItem> GetTodoItemAsync(int todoItemId);
    Task CreateTodoItem(TaskItemDto dto);
}

public class ToDoItemService : IToDoItemService
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

    public async Task CreateTodoItem(TaskItemDto dto)
    {
        var newTodoTask = new TaskItem
        {
            Id = dto.Id,
            Name = dto.Name,
            CreationDate = dto.CreationDate,
            CompletionDate = dto.CompletionDate,
            Description = dto.Description,
            IsDone = dto.IsDone
        };

        await _taskRepository.CreateOneAsync(newTodoTask);
    }
}