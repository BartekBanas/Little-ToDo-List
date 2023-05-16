using AutoMapper;
using LittleToDoList.Business.Abstractions;
using LittleToDoList.Business.Entities;

namespace LittleToDoList.Application.Services;

public class ToDoItemService
{
    private readonly IRepository<TaskItem> _accountRepository;
    private readonly IMapper _mapper;
}