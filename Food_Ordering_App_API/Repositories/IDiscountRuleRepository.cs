using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public interface IDiscountRuleRepository
    {
        IQueryable<DiscountRule> GetAll();
        DiscountRule GetById(int id);
        void Add(DiscountRule entity);
        void Update(DiscountRule entity);
        void Delete(DiscountRule entity);
        DiscountRule GetActiveDiscountRule();
        bool SaveChanges();
    }
}
