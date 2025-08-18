namespace Food_Ordering_App_API.DTOs.Menu___Menu_Item_DTOs
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public List<MenuItemDtoForMenu> MenuItems { get; set; }
    }
}
