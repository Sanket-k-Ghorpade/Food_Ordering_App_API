using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll();
        Order GetById(int id);
        void Add(Order entity);
        void Update(Order entity); // Added
        void Delete(Order entity); // Added
        bool SaveChanges();
    }
}
