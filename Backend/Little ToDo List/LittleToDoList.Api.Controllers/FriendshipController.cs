using LittleToDoList.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LittleToDoList.Api.Controllers;

[ApiController]
[Route("api/friendship")]
public class FriendshipController : Controller
{
    private readonly IFriendshipService _friendshipService;

    public FriendshipController(IFriendshipService friendshipService)
    {
        _friendshipService = friendshipService;
    }

    [HttpPost]
    public async Task<IActionResult> Befriend([FromQuery]Guid firstAccountId, [FromQuery]Guid secondAccountId)
    {
        await _friendshipService.CreateFriendship(firstAccountId, secondAccountId);

        return Ok();
    }
}