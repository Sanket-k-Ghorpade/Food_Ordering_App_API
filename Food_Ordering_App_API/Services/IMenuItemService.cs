using Food_Ordering_App_API.DTOs.Menu_Item_DTOs;

namespace Food_Ordering_App_API.Services
{
    public interface IMenuItemService
    {
        IEnumerable<MenuItemDto> GetAllItems();
        MenuItemDto GetItemById(int id);
        IEnumerable<MenuItemDto> SearchItems(string keyword);
        MenuItemDto AddMenuItem(MenuItemCreateDto menuItemDto);
        MenuItemDto UpdateMenuItem(int id, MenuItemUpdateDto menuItemDto);
        bool DeleteMenuItem(int id);
    }

}
