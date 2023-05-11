﻿using Microsoft.AspNetCore.Mvc;

namespace LittleToDoList.Api.Controllers;

[ApiController]
[Route("api/task")]
public class ToDoTaskController
{
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
    public async Task<IActionResult> CreateTask()
    {
        throw new NotImplementedException();
    }

    [HttpPut("{taskId:int}")]
    public async Task<IActionResult> UpdateTask([FromRoute] int taskId)
    {
        throw new NotImplementedException();
    }
}