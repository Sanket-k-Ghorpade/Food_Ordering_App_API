using Food_Ordering_App_API.DTOs.Menu_Item_DTOs;
using Food_Ordering_App_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MenuItemsController : ControllerBase
{
    private readonly IMenuItemService _menuItemService;
    public MenuItemsController(IMenuItemService menuItemService)
    {
        _menuItemService = menuItemService;
    }

    [HttpGet]
    [AllowAnonymous]
    public ActionResult<IEnumerable<MenuItemDto>> GetItems()
    {
        return Ok(_menuItemService.GetAllItems());
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public ActionResult<MenuItemDto> GetItem(int id)
    {
        var item = _menuItemService.GetItemById(id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpGet("search")]
    [AllowAnonymous]
    public ActionResult<IEnumerable<MenuItemDto>> SearchItems([FromQuery] string keyword)
    {
        return Ok(_menuItemService.SearchItems(keyword));
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public ActionResult<MenuItemDto> AddItem([FromBody] MenuItemCreateDto itemDto)
    {
        var newItem = _menuItemService.AddMenuItem(itemDto);
        return CreatedAtAction(nameof(GetItem), new { id = newItem.MenuItemId }, newItem);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")]
    public ActionResult<MenuItemDto> UpdateItem(int id, [FromBody] MenuItemUpdateDto itemDto)
    {
        var updatedItem = _menuItemService.UpdateMenuItem(id, itemDto);
        if (updatedItem == null) return NotFound();
        return Ok(updatedItem);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public IActionResult DeleteItem(int id)
    {
        if (!_menuItemService.DeleteMenuItem(id)) return NotFound();
        return NoContent();
    }
}