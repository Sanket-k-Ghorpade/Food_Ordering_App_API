using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Ordering_App_API.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FoodOrderingAppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(FoodOrderingAppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }
    }

}
