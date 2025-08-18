using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public interface IMenuRepository
    {
        //IEnumerable<MenuDto> GetAll();
        IQueryable<Menu> GetAll();
        Menu GetById(int id);
        void Add(Menu menu);
        void Update(Menu menu);
        void Delete(Menu menu);
        IEnumerable<MenuItem> GetMenuItems(int menuId);
        bool SaveChanges();
    }
}
