using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.DTOs.Order_DTOs
{
    public class OrderCreateDto
    {
        public List<OrderItemCreateDto> OrderItems { get; set; }
        public PaymentMode PaymentMode { get; set; }
    }
}
