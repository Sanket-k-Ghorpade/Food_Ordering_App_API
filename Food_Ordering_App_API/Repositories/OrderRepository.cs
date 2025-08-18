using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Ordering_App_API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly FoodOrderingAppDbContext _context;
        public OrderRepository(FoodOrderingAppDbContext context)
        {
            _context = context;
        }
        public IQueryable<Order> GetAll()
        {
            // Eagerly load all related data needed for the invoice DTO
            return _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.MenuItem) // Include MenuItem for the name
                .Include(o => o.DeliveryPartner);
        }

        public Order GetById(int id)
        {
            // Use the pre-configured GetAll to ensure all includes are present
            return GetAll().FirstOrDefault(o => o.OrderId == id);
        }


        public void Add(Order entity) => _context.Orders.Add(entity);
        public void Update(Order entity) => _context.Orders.Update(entity); // Added
        public void Delete(Order entity) => _context.Orders.Remove(entity); // Added
        public bool SaveChanges() => (_context.SaveChanges() > 0);


    }
}
