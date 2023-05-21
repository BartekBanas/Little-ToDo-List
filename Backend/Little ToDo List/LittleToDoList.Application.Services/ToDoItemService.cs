using AutoMapper;
using LittleToDoList.Application.Dto;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;
using LittleToDoList.Business.Events;

namespace LittleToDoList.Application.Services;

public interface IToDoItemService
{
    Task<TaskItem> GetTodoItemAsync(int todoItemId);
    Task<ICollection<TaskItemDto>> GetAllTodoItemsAsync();
    Task CreateTodoItem(TaskCreateDto dto);
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
    
    public async Task<ICollection<TaskItemDto>> GetAllTodoItemsAsync()
    {
        var taskItems = await _taskRepository.GetAllAsync();

        var dtos = _mapper.Map<ICollection<TaskItemDto>>(taskItems);

        return dtos;
    }

    public async Task CreateTodoItem(TaskCreateDto dto)
    {
        var newTodoTask = TaskItem.CreateInstance(
            name: dto.Name,
            description: dto.Description
        );

        await _taskRepository.CreateOneAsync(newTodoTask);

        newTodoTask.AddDomainEvent(new TodoCreated(newTodoTask));

        await _taskRepository.SaveChangesAsync();
    }
}