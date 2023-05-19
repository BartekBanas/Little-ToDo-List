using LittleToDoList.Application.Dto;
using LittleToDoList.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LittleToDoList.Api.Controllers.Controllers;

[ApiController]
[Route("api/task")]
public class ToDoTaskController
{
    private readonly IToDoItemService _toDoItemService;

    public ToDoTaskController(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    [HttpGet]
    public async Task<IActionResult> ReturnAllTasks()
    {
        throw new NotImplementedException();
    }

    [HttpGet("{taskId:int}")]
    public async Task<IActionResult> ReturnSpecificTask([FromRoute] int taskId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItemDto taskItem)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{taskId:int}")]
    public async Task<IActionResult> UpdateTask([FromRoute] int taskId)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    public IActionResult GetTasks(int pageSize = 10, int pageNumber = 0)
    {
        throw new NotImplementedException();
    }
}