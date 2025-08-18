namespace Food_Ordering_App_API.Controllers
{
    using global::Food_Ordering_App_API.Models;
    using global::Food_Ordering_App_API.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace Food_Ordering_App_API.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class AuthController : ControllerBase
        {
            private readonly IAuthService _authService;

            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpPost("login")]
            public IActionResult Login([FromBody] LoginViewModel model)
            {
                var response = _authService.Login(model);
                if (!response.IsSuccess)
                    return Unauthorized("Invalid credentials");

                return Ok(response);
            }
        }
    }

}
