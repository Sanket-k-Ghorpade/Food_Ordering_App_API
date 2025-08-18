using Food_Ordering_App_API.DTOs.Menu___Menu_Item_DTOs;
using Food_Ordering_App_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Food_Ordering_App_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet]
        [AllowAnonymous] // Anyone can view menu
        public IActionResult GetMenus() => Ok(_menuService.GetAllMenus());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetMenuById(int id) => Ok(_menuService.GetMenuById(id));



        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public IActionResult CreateMenu([FromBody] MenuCreateDto menuCreateDto)
        {
            var menu = _menuService.AddMenu(menuCreateDto);
            if (menu != null)
            {
                return Ok(menu);
            }
            return BadRequest("Operation failed.");
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult UpdateMenu(int id, [FromBody] MenuUpdateDto menuUpdateDto)
        {
            var updatedMenu = _menuService.UpdateMenu(id, menuUpdateDto);
            if (updatedMenu != null)
            {
                return Ok(updatedMenu);
            }
            return NotFound($"Menu with Id {id} was not found..");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult DeleteMenu(int id)
        {
            bool isDeleted = _menuService.DeleteMenu(id);
            if (isDeleted)
            {
                return Ok($"Menu with Id {id} is deleted..");
            }
            return BadRequest("Operation failed..");
        }
    }
}
