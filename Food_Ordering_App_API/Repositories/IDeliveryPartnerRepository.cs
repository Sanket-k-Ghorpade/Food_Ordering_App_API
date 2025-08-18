using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public interface IDeliveryPartnerRepository
    {
        IQueryable<DeliveryPartner> GetAll();
        DeliveryPartner GetById(int id);
        void Add(DeliveryPartner entity);
        void Update(DeliveryPartner entity);
        void Delete(DeliveryPartner entity);
        DeliveryPartner GetRandomAvailablePartner();
        bool SaveChanges();
    }
}
