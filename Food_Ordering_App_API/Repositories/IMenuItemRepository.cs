using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public interface IMenuItemRepository
    {
        IQueryable<MenuItem> GetAll();
        MenuItem GetById(int id);
        void Add(MenuItem entity);
        void Update(MenuItem entity);
        void Delete(MenuItem entity);
        bool SaveChanges();

    }
}
