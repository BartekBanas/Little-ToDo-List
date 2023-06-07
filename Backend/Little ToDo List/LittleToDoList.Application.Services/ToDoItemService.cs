using AutoMapper;
using LittleToDoList.Application.Dto;
using LittleToDoList.Application.Dto.Mapping;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;
using LittleToDoList.Business.Events;

namespace LittleToDoList.Application.Services;

public interface IToDoItemService
{
    Task<ToDo> GetTodoItemAsync(int todoItemId);
    Task<ICollection<ToDoItemDto>> GetAllTodoItemsAsync();
    Task CreateTodoItem(ToDoCreateDto dto);
    Task<ToDoItemDto> UpdateTaskItemAsync(int id, ToDoUpdateDto updateDto);
    Task DeleteTodoItem(int todoItemId);
    Task<IEnumerable<ToDoItemDto>> GetTasks(int pageSize, int pageNumber);
}

public class ToDoItemService : IToDoItemService
{
    private readonly IRepository<ToDo> _taskRepository;
    private readonly IMapper _mapper;

    public ToDoItemService(IRepository<ToDo> taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    public async Task<ToDo> GetTodoItemAsync(int todoItemId)
    {
        var taskItem = await _taskRepository.GetOneAsync(todoItemId);

        var dto = _mapper.Map<ToDo>(taskItem);

        return dto;
    }
    
    public async Task<ICollection<ToDoItemDto>> GetAllTodoItemsAsync()
    {
        var taskItems = await _taskRepository.GetAllAsync();

        var dtos = _mapper.Map<ICollection<ToDoItemDto>>(taskItems);

        return dtos;
    }

    public async Task CreateTodoItem(ToDoCreateDto dto)
    {
        var newTodoTask = ToDo.CreateInstance(
            name: dto.Name,
            description: dto.Description
        );

        await _taskRepository.CreateOneAsync(newTodoTask);

        newTodoTask.AddDomainEvent(new TodoCreated(newTodoTask));

        await _taskRepository.SaveChangesAsync();
    }
    
    public async Task<ToDoItemDto> UpdateTaskItemAsync(int id, ToDoUpdateDto updateDto)
    {
        var entity = await _taskRepository.UpdateAsync(updateDto, id);

        var updatedDto = entity.ToDto();
;
        await _taskRepository.SaveChangesAsync();
        
        return updatedDto;
    }

    public async Task DeleteTodoItem(int todoItemId)
    {
        await _taskRepository.DeleteOneAsync(todoItemId);

        await _taskRepository.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<ToDoItemDto>> GetTasks(int pageSize, int pageNumber)
    {
        var pagedEntities = await _taskRepository.GetPagedAsync(pageSize, pageNumber);

        return pagedEntities.Select(taskItem => taskItem.ToDto());
    }
}