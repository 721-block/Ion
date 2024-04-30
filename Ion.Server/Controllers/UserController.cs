using Ion.Application.IServices;
using Ion.Application.ViewModels;
using Ion.Server.RequestEntities.User;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ion.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService, IMapper mapper) : Controller
{
    [HttpGet("{userId:int}", Name = nameof(GetUserById))]
    public ActionResult<UserToGet> GetUserById([FromRoute] int userId)
    {
        var user = userService.GetById(userId);
        if (user is null)
            return NotFound();
        var userToGet = mapper.Map<UserToGet>(user);
        return Ok(userToGet);
    }

    [HttpGet(Name = nameof(GetAllUsers))]
    public ActionResult<IEnumerable<UserToGet>> GetAllUsers()
    {
        var users = userService.GetAll();
        return Ok(users.Select(mapper.Map<UserToGet>));
    }

    [HttpPost(Name = nameof(CreateUser))]
    public async Task<IActionResult> CreateUser([FromBody] UserToPost user)
    {
        if (user is null) 
            return BadRequest("User is empty");
        if (!ModelState.IsValid)
            return UnprocessableEntity();
        var userToPost = mapper.Map<UserViewModel>(user);
        var createdUser = await userService.AddAsync(userToPost);
        return CreatedAtRoute(nameof(GetUserById), new {userId = createdUser.Id}, createdUser.Id);
    }

    [HttpPatch("{userId:int}", Name = nameof(UpdateUser))]
    public async Task<IActionResult> UpdateUser(int userId, [FromBody] UserToPatch userToPatch)
    {
        var user = mapper.Map<UserViewModel>(userToPatch);
        user.Id = userId;
        await userService.UpdateAsync(user);
        return Ok();
    }

    [HttpDelete("{userId:int}", Name = nameof(DeleteUser))]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        await userService.DeleteAsync(new UserViewModel {Id = userId});
        return Ok();
    }
}