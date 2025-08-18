using Food_Ordering_App_API.DTOs.Order_DTOs;
using Food_Ordering_App_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    [Authorize(Roles = "ADMIN")] // Only admins can see all orders
    public ActionResult<IEnumerable<OrderDto>> GetAllOrders()
    {
        return Ok(_orderService.GetAllOrders());
    }

    [HttpPost]
    public ActionResult<OrderDto> PlaceOrder([FromBody] OrderCreateDto orderDto)
    {
        try
        {
            // Get the user ID from the token claims
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var createdOrderInvoice = _orderService.PlaceOrder(orderDto, userId);

            // Return a 201 Created status with the location and the invoice
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrderInvoice.OrderId }, createdOrderInvoice);
        }
        catch (KeyNotFoundException ex)
        {
            // If a MenuItemId was invalid
            return BadRequest(new { message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            // If no delivery partner was available
            return StatusCode(503, new { message = ex.Message }); // 503 Service Unavailable
        }
    }

    [HttpGet("{id}")]
    public ActionResult<OrderDto> GetOrder(int id)
    {
        // Extract user details from the token for the authorization check
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var userRole = User.FindFirstValue(ClaimTypes.Role);

        var order = _orderService.GetOrderById(id, userId, userRole);

        // This now correctly returns NotFound for both a non-existent order
        // and an order the user is not authorized to see.
        if (order == null) return NotFound();

        return Ok(order);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "ADMIN")] // Only Admins can update orders
    public ActionResult<OrderDto> UpdateOrder(int id, [FromBody] OrderUpdateDto orderDto)
    {
        var updatedOrder = _orderService.UpdateOrder(id, orderDto);
        if (updatedOrder == null) return NotFound();
        return Ok(updatedOrder);
    }

    [HttpDelete("{id}")]
    public IActionResult CancelOrder(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var userRole = User.FindFirstValue(ClaimTypes.Role);

        var success = _orderService.CancelOrder(id, userId, userRole);

        // If success is false, it's either because the order didn't exist
        // or the user was not authorized. We return NotFound in both cases
        // to avoid leaking information.
        if (!success) return NotFound();

        return Ok($"Order with Id {id} is Cancelled..");
    }
}