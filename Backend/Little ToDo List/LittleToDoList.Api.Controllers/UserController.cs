using LittleToDoList.Application.Dto;
using LittleToDoList.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LittleToDoList.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }
    
    [HttpGet("{userId:Guid}")]
    public async Task<IActionResult> ReturnSpecificUser([FromRoute] Guid userId)
    {
        var user = await _userService.GetUserAsync(userId);

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] UserCreateDto userDto)
    {
        await _userService.CreateUser(userDto);

        return Ok();
    }
    
    [HttpPut("{userId:Guid}")]
    public async Task<IActionResult> UpdateUser([FromRoute] Guid userId, [FromBody] UserUpdateDto updateDto)
    {
        var updatedUser = await _userService.UpdateUserAsync(userId, updateDto);

        return Ok(updatedUser);
    }
    
    [HttpDelete("{userId:Guid}")]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
    {
        await _userService.DeleteUser(userId);

        return Ok();
    }
}