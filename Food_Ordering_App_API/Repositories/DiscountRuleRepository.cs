using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Repositories;

public class DiscountRuleRepository : IDiscountRuleRepository
{
    private readonly FoodOrderingAppDbContext _context;

    public DiscountRuleRepository(FoodOrderingAppDbContext context)
    {
        _context = context;
    }

    public IQueryable<DiscountRule> GetAll() => _context.DiscountRules;

    public DiscountRule GetById(int id) => _context.DiscountRules.Find(id);

    public void Add(DiscountRule entity) => _context.DiscountRules.Add(entity);

    public void Update(DiscountRule entity) => _context.DiscountRules.Update(entity);

    public void Delete(DiscountRule entity) => _context.DiscountRules.Remove(entity);

    public bool SaveChanges() => (_context.SaveChanges() > 0);

    public DiscountRule GetActiveDiscountRule()
    {
        // Assuming the "active" rule is the first one found.
        // This logic can be changed here if business rules evolve (e.g., OrderByDescending).
        return _context.DiscountRules.FirstOrDefault();
    }
}