using Food_Ordering_App_API.DTOs.User_DTOs;
using Food_Ordering_App_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "ADMIN")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }

    [HttpGet("{id}")]
    public ActionResult<UserDto> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    // This endpoint could be public in a real application's AccountController,
    // but here it is an admin-only action as per the original design.
    [HttpPost("register")]
    public ActionResult<UserDto> RegisterUser([FromBody] UserCreateDto userDto)
    {
        var newUser = _userService.RegisterUser(userDto);
        return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
    }

    [HttpPut("{id}")]
    public ActionResult<UserDto> UpdateUser(int id, [FromBody] UserUpdateDto userDto)
    {
        var updatedUser = _userService.UpdateUser(id, userDto);
        if (updatedUser == null) return NotFound();
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        if (!_userService.DeleteUser(id)) return NotFound();
        return NoContent();
    }
}