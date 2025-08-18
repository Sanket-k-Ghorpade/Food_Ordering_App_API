using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        User GetById(int id);
        User GetByUserName(string username);
        void Add(User entity);
        void Update(User entity);
        void Delete(User entity);
        bool SaveChanges();
    }
}
