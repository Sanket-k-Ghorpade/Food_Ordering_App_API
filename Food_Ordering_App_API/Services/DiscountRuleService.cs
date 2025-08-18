using AutoMapper;
using Food_Ordering_App_API.DTOs.Discount_Rule_DTOs;
using Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Repositories;

namespace Food_Ordering_App_API.Services
{
    public class DiscountRuleService : IDiscountRuleService
    {
        private readonly IDiscountRuleRepository _discountRuleRepository;
        private readonly IMapper _mapper;

        public DiscountRuleService(IDiscountRuleRepository discountRuleRepository, IMapper mapper)
        {
            _discountRuleRepository = discountRuleRepository;
            _mapper = mapper;
        }

        public IEnumerable<DiscountRuleDto> GetAllRules()
        {
            var rulesQuery = _discountRuleRepository.GetAll();
            return _mapper.ProjectTo<DiscountRuleDto>(rulesQuery).ToList();
        }

        public DiscountRuleDto GetRuleById(int id)
        {
            var rule = _discountRuleRepository.GetById(id);
            return _mapper.Map<DiscountRuleDto>(rule);
        }

        public DiscountRuleDto GetActiveRule()
        {
            var rule = _discountRuleRepository.GetActiveDiscountRule();
            return _mapper.Map<DiscountRuleDto>(rule);
        }

        public DiscountRuleDto AddRule(DiscountRuleCreateDto ruleDto)
        {
            var rule = _mapper.Map<DiscountRule>(ruleDto);
            _discountRuleRepository.Add(rule);
            _discountRuleRepository.SaveChanges();
            return _mapper.Map<DiscountRuleDto>(rule);
        }

        public DiscountRuleDto UpdateRule(int id, DiscountRuleUpdateDto ruleDto)
        {
            var ruleFromRepo = _discountRuleRepository.GetById(id);
            if (ruleFromRepo == null) return null;

            _mapper.Map(ruleDto, ruleFromRepo);
            _discountRuleRepository.Update(ruleFromRepo);
            _discountRuleRepository.SaveChanges();
            return _mapper.Map<DiscountRuleDto>(ruleFromRepo);
        }

        public bool DeleteRule(int id)
        {
            var ruleFromRepo = _discountRuleRepository.GetById(id);
            if (ruleFromRepo == null) return false;

            _discountRuleRepository.Delete(ruleFromRepo);
            return _discountRuleRepository.SaveChanges();
        }
    }

}
