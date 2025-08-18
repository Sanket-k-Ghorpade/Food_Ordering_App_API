namespace Food_Ordering_App_API.DTOs.Order_DTOs
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; } // Sum of all LineTotals
        public decimal DiscountApplied { get; set; } // Applied discount
        public decimal FinalAmount { get; set; } // Total - Discount
        public string PaymentMode { get; set; }
        public OrderDeliveryPartnerDto DeliveryPartner { get; set; } // Nested partner details
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
