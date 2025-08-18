using Food_Ordering_App_API.DTOs.Menu___Menu_Item_DTOs;
using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Services
{
    public interface IMenuService
    {
        IEnumerable<MenuDto> GetAllMenus();
        MenuDto GetMenuById(int id);
        IEnumerable<MenuItem> GetMenuItems(int menuId);
        MenuDto AddMenu(MenuCreateDto menuCreateDto);
        MenuDto UpdateMenu(int id, MenuUpdateDto menuUpdateDto);
        bool DeleteMenu(int id);
    }

}
