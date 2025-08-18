using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Ordering_App_API.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly FoodOrderingAppDbContext _context;
        public MenuRepository(FoodOrderingAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Menu> GetAll()
        {
            // Return the IQueryable. The query is not executed here.
            // Include the related MenuItems for the projection.
            return _context.Menus.Include(m => m.MenuItems);
        }

        public Menu GetById(int id)
        {
            return _context.Menus.Include(m => m.MenuItems).FirstOrDefault(m => m.MenuId == id);
        }

        public void Add(Menu menu)
        {
            _context.Menus.Add(menu);
        }

        public void Update(Menu menu)
        {
            _context.Menus.Update(menu);
        }

        public bool SaveChanges()
        {
            // Commits the changes to the database
            return (_context.SaveChanges() > 0);

        }
        public void Delete(Menu menu)
        {
            _context.Menus.Remove(menu);
        }
        public IEnumerable<MenuItem> GetMenuItems(int menuId)
        {
            return _context.MenuItems.Where(mi => mi.MenuId == menuId).ToList();
        }
    }

}
