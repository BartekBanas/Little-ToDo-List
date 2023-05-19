using LittleToDoList.Application.Dto;
using LittleToDoList.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LittleToDoList.Api.Controllers;

[ApiController]
[Route("api/task")]
public class ToDoTaskController : Controller
{
    private readonly IToDoItemService _toDoItemService;

    public ToDoTaskController(IToDoItemService toDoItemService)
    {
        _toDoItemService = toDoItemService;
    }

    // [HttpGet]
    // public async Task<IActionResult> ReturnAllTasks()
    // {
    //     throw new NotImplementedException();
    // }

    [HttpGet("{taskId:int}")]
    public async Task<IActionResult> ReturnSpecificTask([FromRoute] int taskId)
    {
        var task = await _toDoItemService.GetTodoItemAsync(taskId);

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskItemDto taskItem)
    {
        await _toDoItemService.CreateTodoItem(taskItem);

        return Ok();
    }

    // [HttpPut("{taskId:int}")]
    // public async Task<IActionResult> UpdateTask([FromRoute] int taskId)
    // {
    //     throw new NotImplementedException();
    // }
    //
    // [HttpGet]
    // public IActionResult GetTasks(int pageSize = 10, int pageNumber = 0)
    // {
    //     throw new NotImplementedException();
    // }
}