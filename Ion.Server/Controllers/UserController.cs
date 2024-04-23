using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : Controller
{
    [HttpGet("{userId:int}", Name = nameof(GetUserById))]
    public ActionResult<UserViewModel> GetUserById([FromRoute] int userId)
    {
        var user = userService.GetById(userId);
        if (user is null)
            return NotFound();
        return Ok(user);
    }

    [HttpGet(Name = nameof(GetAllUsers))]
    public ActionResult<IEnumerable<UserViewModel>> GetAllUsers()
    {
        var users = userService.GetAll();
        return Ok(users);
    }

    [HttpPost(Name = nameof(CreateUser))]
    public async Task<IActionResult> CreateUser([FromBody] UserViewModel user)
    {
        if (user is null) 
            return BadRequest("User is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        var createdUser = await userService.AddAsync(user);
        return CreatedAtRoute(nameof(GetUserById), new {userId = createdUser.Id}, createdUser.Id);
    }
}