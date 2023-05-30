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

    [HttpGet]
    public async Task<IActionResult> ReturnAllTasks()
    {
        var taskItemDtos = await _toDoItemService.GetAllTodoItemsAsync();

        return Ok(taskItemDtos);
    }

    [HttpGet("{taskId:int}")]
    public async Task<IActionResult> ReturnSpecificTask([FromRoute] int taskId)
    {
        var task = await _toDoItemService.GetTodoItemAsync(taskId);

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto taskCreateDto)
    {
        await _toDoItemService.CreateTodoItem(taskCreateDto);

        return Ok();
    }
    
    [HttpDelete("{taskId:int}")]
    public async Task<IActionResult> DeleteSpecificTask([FromRoute] int taskId)
    {
        await _toDoItemService.DeleteTodoItem(taskId);

        return Ok();
    }

    [HttpPut("{taskId:int}")]
    public async Task<IActionResult> UpdateTask([FromRoute] int taskId, [FromBody] TaskUpdateDto updateDto)
    {
        var updatedItem = await _toDoItemService.UpdateTaskItemAsync(taskId, updateDto);

        return Ok(updatedItem);
    }
    
    [HttpGet]
    public IActionResult GetTasks([FromQuery]int pageSize = 10, [FromQuery]int pageNumber = 0)
    {
        var tasks = _toDoItemService.GetTasks(pageSize, pageNumber);
        return Ok(tasks);
    }
}