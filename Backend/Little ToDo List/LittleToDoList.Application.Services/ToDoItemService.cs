using System.Linq.Expressions;
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
    Task<ICollection<ToDoDto>> GetAllTodoItemsAsync();
    Task CreateTodoItem(ToDoCreateDto dto);
    Task<ToDoDto> UpdateTaskItemAsync(int id, ToDoUpdateDto updateDto);
    Task DeleteTodoItem(int todoItemId);
    Task<IEnumerable<ToDoDto>> GetTasks(int pageSize, int pageNumber);
    Task<IEnumerable<ToDoDto>> GetTasks(Guid accountId);
}

public class ToDoItemService : IToDoItemService
{
    private readonly IRepository<ToDo> _taskRepository;
    private readonly IRepository<User> _userRepository;
    private readonly IMapper _mapper;

    public ToDoItemService(IRepository<ToDo> taskRepository, IRepository<User> userRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ToDo> GetTodoItemAsync(int todoItemId)
    {
        var taskItem = await _taskRepository.GetOneAsync(todoItemId);

        var dto = _mapper.Map<ToDo>(taskItem);

        return dto;
    }
    
    public async Task<ICollection<ToDoDto>> GetAllTodoItemsAsync()
    {
        var taskItems = await _taskRepository.GetAllAsync();

        var dtos = _mapper.Map<ICollection<ToDoDto>>(taskItems);

        return dtos;
    }

    public async Task CreateTodoItem(ToDoCreateDto dto)
    {
        var account = _userRepository.GetOneRequiredAsync(dto.AssignedUserId);
        
        var newTodoTask = ToDo.CreateInstance(
            name: dto.Name,
            description: dto.Description,
            assignedUserId: account.Result.Id
        );

        await _taskRepository.CreateOneAsync(newTodoTask);

        newTodoTask.AddDomainEvent(new TodoCreated(newTodoTask));

        await _taskRepository.SaveChangesAsync();
    }
    
    public async Task<ToDoDto> UpdateTaskItemAsync(int id, ToDoUpdateDto updateDto)
    {
        var entity = await _taskRepository.UpdateAsync(updateDto, id);

        var updatedDto = entity.ToDto();
        
        await _taskRepository.SaveChangesAsync();
        
        return updatedDto;
    }

    public async Task DeleteTodoItem(int todoItemId)
    {
        await _taskRepository.DeleteOneAsync(todoItemId);

        await _taskRepository.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<ToDoDto>> GetTasks(int pageSize, int pageNumber)
    {
        var pagedEntities = await _taskRepository.GetPagedAsync(pageSize, pageNumber);

        return pagedEntities.Select(taskItem => taskItem.ToDto());
    }

    public async Task<IEnumerable<ToDoDto>> GetTasks(Guid accountId)
    {
        Expression<Func<ToDo, bool>> filer = toDo => toDo.AssignedUserId.Equals(accountId);
        
        var toDos = await _taskRepository
            .GetAsync(filer, null, nameof(ToDo.AssignedUser));

        var dtos = _mapper.Map<IEnumerable<ToDoDto>>(toDos);

        return dtos;
    }
}