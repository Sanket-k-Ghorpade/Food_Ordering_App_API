using AutoMapper;
using Food_Ordering_App_API.DTOs.Order_DTOs;
using Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Repositories;
using Food_Ordering_App_API.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMenuItemRepository _menuItemRepository;
    private readonly IDiscountRuleRepository _discountRuleRepository;
    private readonly IDeliveryPartnerRepository _deliveryPartnerRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository,
                        IDiscountRuleRepository discountRuleRepository, IDeliveryPartnerRepository deliveryPartnerRepository,
                        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _menuItemRepository = menuItemRepository;
        _discountRuleRepository = discountRuleRepository;
        _deliveryPartnerRepository = deliveryPartnerRepository;
        _mapper = mapper;
    }

    public OrderDto PlaceOrder(OrderCreateDto orderDto, int userId)
    {
        // 1. Fetch Menu Item details and calculate total
        var orderItems = new List<OrderItem>();
        decimal totalAmount = 0;

        foreach (var itemDto in orderDto.OrderItems)
        {
            var menuItem = _menuItemRepository.GetById(itemDto.MenuItemId);
            if (menuItem == null) throw new KeyNotFoundException($"Menu Item with ID {itemDto.MenuItemId} not found.");

            var orderItem = new OrderItem
            {
                MenuItemId = menuItem.MenuItemId,
                Quantity = itemDto.Quantity,
                Price = menuItem.MenuItemPrice // Lock in the price at the time of order
            };
            orderItems.Add(orderItem);
            totalAmount += orderItem.Quantity * orderItem.Price;
        }

        // 2. Apply Discount based on the best matching rule
        var allRules = _discountRuleRepository.GetAll();
        decimal discountApplied = 0;

        // Find the best rule that the order qualifies for
        // We filter for applicable rules and then take the one with the highest minimum value
        var bestApplicableRule = allRules
            .Where(rule => totalAmount >= rule.MinOrderValue)
            .OrderByDescending(rule => rule.MinOrderValue)
            .FirstOrDefault();

        if (bestApplicableRule != null)
        {
            discountApplied = bestApplicableRule.FlatDiscount;
        }

        // 3. Assign an available Delivery Partner
        var deliveryPartner = _deliveryPartnerRepository.GetRandomAvailablePartner();
        if (deliveryPartner == null) throw new InvalidOperationException("No available delivery partners at the moment.");

        // 4. Create the final Order entity
        var newOrder = new Order
        {
            UserId = userId,
            OrderDate = DateTime.UtcNow,
            TotalAmount = totalAmount,
            DiscountApplied = discountApplied,
            FinalAmount = totalAmount - discountApplied,
            PaymentMode = orderDto.PaymentMode,
            DeliveryPartnerId = deliveryPartner.DeliveryPartnerId,
            OrderItems = orderItems
        };

        // 5. Save to the database in a single transaction
        _orderRepository.Add(newOrder);
        _orderRepository.SaveChanges();

        // 6. Fetch the fully loaded record to ensure all navigation properties are available for mapping
        var savedOrder = _orderRepository.GetById(newOrder.OrderId);

        // 7. Return the "Invoice" DTO
        return _mapper.Map<OrderDto>(savedOrder);
    }

    public IEnumerable<OrderDto> GetAllOrders()
    {
        var ordersQuery = _orderRepository.GetAll();
        return _mapper.ProjectTo<OrderDto>(ordersQuery).ToList();
    }

    public OrderDto GetOrderById(int orderId, int userId, string userRole)
    {
        var order = _orderRepository.GetById(orderId);
        if (order == null) return null;

        // **AUTHORIZATION LOGIC**
        // Allow if the user is an ADMIN or if the order's UserId matches the caller's UserId.
        if (userRole == "ADMIN" || order.UserId == userId)
        {
            return _mapper.Map<OrderDto>(order);
        }

        // If neither condition is met, the user is not authorized. Return null.
        return null;
    }

    public OrderDto UpdateOrder(int orderId, OrderUpdateDto orderDto)
    {
        var orderFromRepo = _orderRepository.GetById(orderId);
        if (orderFromRepo == null) return null;

        _mapper.Map(orderDto, orderFromRepo);
        _orderRepository.Update(orderFromRepo);
        _orderRepository.SaveChanges();

        return _mapper.Map<OrderDto>(orderFromRepo);
    }

    public bool CancelOrder(int orderId, int userId, string userRole)
    {
        var orderFromRepo = _orderRepository.GetById(orderId);
        if (orderFromRepo == null) return false;

        // **AUTHORIZATION LOGIC**
        // Only an ADMIN or the user who owns the order can cancel it.
        if (userRole != "ADMIN" && orderFromRepo.UserId != userId)
        {
            return false; // Not authorized
        }

        _orderRepository.Delete(orderFromRepo);
        return _orderRepository.SaveChanges();
    }
}