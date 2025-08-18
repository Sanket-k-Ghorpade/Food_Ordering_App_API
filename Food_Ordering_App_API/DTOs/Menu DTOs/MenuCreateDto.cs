using Food_Ordering_App_API.DTOs.Menu_Item_DTOs;

namespace Food_Ordering_App_API.DTOs.Menu___Menu_Item_DTOs
{
    public class MenuCreateDto
    {
        public string MenuName { get; set; }
        public List<MenuItemCreateDtoForMenu>? MenuItems { get; set; }
    }
}
