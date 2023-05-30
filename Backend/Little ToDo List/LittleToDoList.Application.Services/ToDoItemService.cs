﻿using AutoMapper;
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
    Task<TaskItemDto> UpdateTaskItemAsync(int id, TaskUpdateDto updateDto);
    Task DeleteTodoItem(int todoItemId);
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
    
    public async Task<TaskItemDto> UpdateTaskItemAsync(int id, TaskUpdateDto updateDto)
    {
        var entity = await _taskRepository.UpdateAsync(updateDto, id);

        var updatedDto = new TaskItemDto(entity.Id, entity.Name, entity.CreationDate)
        {
            CompletionDate = entity.CompletionDate,
            Description = entity.Description,
            IsDone = entity.IsDone
        };

        await _taskRepository.SaveChangesAsync();
        
        return updatedDto;
    }

    public async Task DeleteTodoItem(int todoItemId)
    {
        await _taskRepository.DeleteOneAsync(todoItemId);

        await _taskRepository.SaveChangesAsync();
    }
}