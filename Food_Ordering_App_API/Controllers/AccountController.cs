using Food_Ordering_App_API.DTOs.User_DTOs;
using Food_Ordering_App_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize] // Any authenticated user (MEMBER or ADMIN) can access this
public class AccountController : ControllerBase
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("change-password")]
    public IActionResult ChangePassword([FromBody] ChangePasswordDto passwordDto)
    {
        // Get the current user's ID from their token claims
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var success = _userService.ChangePassword(userId, passwordDto);

        if (!success)
        {
            return BadRequest(new { message = "Password change failed. Please check your old password." });
        }

        return Ok(new { message = "Password changed successfully." });
    }
}