using Food_Ordering_App_API.DTOs.Order_DTOs;

namespace Food_Ordering_App_API.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderDto> GetAllOrders();
        OrderDto GetOrderById(int orderId, int userId, string userRole);
        OrderDto PlaceOrder(OrderCreateDto orderDto, int userId);
        OrderDto UpdateOrder(int orderId, OrderUpdateDto orderDto);
        bool CancelOrder(int orderId, int userId, string userRole);
    }

}
