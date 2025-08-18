using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly FoodOrderingAppDbContext _context;
        public MenuItemRepository(FoodOrderingAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<MenuItem> GetAll() => _context.MenuItems;
        public MenuItem GetById(int id) => _context.MenuItems.Find(id);
        public void Add(MenuItem entity) => _context.MenuItems.Add(entity);
        public void Update(MenuItem entity) => _context.MenuItems.Update(entity);
        public void Delete(MenuItem entity) => _context.MenuItems.Remove(entity);
        public bool SaveChanges() => (_context.SaveChanges() > 0);

    }
}
