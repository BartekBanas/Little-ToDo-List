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

    [HttpGet("{taskId:int}")]
    public async Task<IActionResult> ReturnSpecificTask([FromRoute] int taskId)
    {
        var task = await _toDoItemService.GetTodoItemAsync(taskId);

        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] ToDoCreateDto toDoCreateDto)
    {
        await _toDoItemService.CreateTodoItem(toDoCreateDto);

        return Ok();
    }
    
    [HttpDelete("{taskId:int}")]
    public async Task<IActionResult> DeleteSpecificTask([FromRoute] int taskId)
    {
        await _toDoItemService.DeleteTodoItem(taskId);

        return Ok();
    }

    [HttpPut("{taskId:int}")]
    public async Task<IActionResult> UpdateTask([FromRoute] int taskId, [FromBody] ToDoUpdateDto updateDto)
    {
        var updatedItem = await _toDoItemService.UpdateTaskItemAsync(taskId, updateDto);

        return Ok(updatedItem);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTasks([FromQuery]int pageSize = 10, [FromQuery]int pageNumber = 0)
    {
        var tasks = await _toDoItemService.GetTasks(pageSize, pageNumber);
        return Ok(tasks);
    }
    
    [HttpGet("user")]
    public async Task<IActionResult> GerUsersTasks([FromQuery]Guid accountId)
    {
        var toDoDtos = await _toDoItemService.GetTasks(accountId);
        
        return Ok(toDoDtos);
    }
}