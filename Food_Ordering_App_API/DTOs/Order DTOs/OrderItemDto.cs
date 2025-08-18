namespace Food_Ordering_App_API.DTOs.Order_DTOs
{
    public class OrderItemDto
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } // Enriched with the name
        public int Quantity { get; set; }
        public decimal Price { get; set; } // Price at the time of order
        public decimal LineTotal { get; set; } // Calculated: Quantity * Price
    }
}
