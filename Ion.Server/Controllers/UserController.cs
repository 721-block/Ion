using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
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
    public IActionResult CreateUser([FromBody] UserViewModel user)
    {
        if (user is null)
            return BadRequest("User is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        return Ok();
    }
}