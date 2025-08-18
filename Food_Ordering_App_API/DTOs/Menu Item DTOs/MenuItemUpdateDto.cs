namespace Food_Ordering_App_API.DTOs.Menu_Item_DTOs
{
    public class MenuItemUpdateDto
    {
        public string MenuItemName { get; set; }
        public decimal MenuItemPrice { get; set; }
        public int MenuId { get; set; }
    }
}
