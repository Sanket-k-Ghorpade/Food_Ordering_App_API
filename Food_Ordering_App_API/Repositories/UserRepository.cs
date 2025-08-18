using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Ordering_App_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly FoodOrderingAppDbContext _context;

        public UserRepository(FoodOrderingAppDbContext context)
        {
            _context = context;
        }
        public IQueryable<User> GetAll() => _context.Users.Include(u => u.UserRole);
        public User GetById(int id) => GetAll().FirstOrDefault(u => u.UserId == id);
        public User GetByUserName(string username) => GetAll().FirstOrDefault(u => u.UserName == username);
        public void Add(User entity) => _context.Users.Add(entity);
        public void Update(User entity) => _context.Users.Update(entity);
        public void Delete(User entity) => _context.Users.Remove(entity);
        public bool SaveChanges() => (_context.SaveChanges() > 0);
    }

}
