using AutoMapper;
using Food_Ordering_App_API.DTOs.Delivery_Partner_DTOs;
using Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Repositories;

namespace Food_Ordering_App_API.Services
{
    public class DeliveryPartnerService : IDeliveryPartnerService
    {
        private readonly IDeliveryPartnerRepository _deliveryPartnerRepository;
        private readonly IMapper _mapper;

        public DeliveryPartnerService(IDeliveryPartnerRepository deliveryPartnerRepository, IMapper mapper)
        {
            _deliveryPartnerRepository = deliveryPartnerRepository;
            _mapper = mapper;
        }

        public IEnumerable<DeliveryPartnerDto> GetAllPartners()
        {
            var partnersQuery = _deliveryPartnerRepository.GetAll();
            return _mapper.ProjectTo<DeliveryPartnerDto>(partnersQuery).ToList();
        }

        public DeliveryPartnerDto GetPartnerById(int id)
        {
            var partner = _deliveryPartnerRepository.GetById(id);
            return _mapper.Map<DeliveryPartnerDto>(partner);
        }

        public DeliveryPartnerDto GetRandomAvailablePartner()
        {
            var partner = _deliveryPartnerRepository.GetRandomAvailablePartner();
            return _mapper.Map<DeliveryPartnerDto>(partner);
        }

        public DeliveryPartnerDto AddPartner(DeliveryPartnerCreateDto partnerDto)
        {
            var partner = _mapper.Map<DeliveryPartner>(partnerDto);
            _deliveryPartnerRepository.Add(partner);
            _deliveryPartnerRepository.SaveChanges();
            return _mapper.Map<DeliveryPartnerDto>(partner);
        }

        public DeliveryPartnerDto UpdatePartner(int id, DeliveryPartnerUpdateDto partnerDto)
        {
            var partnerFromRepo = _deliveryPartnerRepository.GetById(id);
            if (partnerFromRepo == null) return null;

            _mapper.Map(partnerDto, partnerFromRepo);
            _deliveryPartnerRepository.Update(partnerFromRepo);
            _deliveryPartnerRepository.SaveChanges();
            return _mapper.Map<DeliveryPartnerDto>(partnerFromRepo);
        }

        public bool DeletePartner(int id)
        {
            var partnerFromRepo = _deliveryPartnerRepository.GetById(id);
            if (partnerFromRepo == null) return false;

            _deliveryPartnerRepository.Delete(partnerFromRepo);
            return _deliveryPartnerRepository.SaveChanges();
        }

    }
}