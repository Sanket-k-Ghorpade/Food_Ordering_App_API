using Food_Ordering_App_API.DTOs.Delivery_Partner_DTOs;

namespace Food_Ordering_App_API.Services
{
    public interface IDeliveryPartnerService
    {
        IEnumerable<DeliveryPartnerDto> GetAllPartners();
        DeliveryPartnerDto GetPartnerById(int id);
        DeliveryPartnerDto GetRandomAvailablePartner();
        DeliveryPartnerDto AddPartner(DeliveryPartnerCreateDto partnerDto);
        DeliveryPartnerDto UpdatePartner(int id, DeliveryPartnerUpdateDto partnerDto);
        bool DeletePartner(int id);
    }

}
