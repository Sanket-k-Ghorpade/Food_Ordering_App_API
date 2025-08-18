using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public class DeliveryPartnerRepository : IDeliveryPartnerRepository
    {
        private readonly FoodOrderingAppDbContext _context;
        private static readonly Random _random = new Random();

        public DeliveryPartnerRepository(FoodOrderingAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<DeliveryPartner> GetAll() => _context.DeliveryPartners;

        public DeliveryPartner GetById(int id) => _context.DeliveryPartners.Find(id);

        public void Add(DeliveryPartner entity) => _context.DeliveryPartners.Add(entity);

        public void Update(DeliveryPartner entity) => _context.DeliveryPartners.Update(entity);

        public void Delete(DeliveryPartner entity) => _context.DeliveryPartners.Remove(entity);

        public bool SaveChanges() => (_context.SaveChanges() > 0);

        public DeliveryPartner GetRandomAvailablePartner()
        {
            var availablePartnersQuery = _context.DeliveryPartners.Where(dp => dp.IsAvailable);

            int count = availablePartnersQuery.Count();
            if (count == 0) return null;

            // Efficiently skip to a random partner in the database
            int randomIndex = _random.Next(count);
            return availablePartnersQuery.Skip(randomIndex).FirstOrDefault();
        }
    }
}
