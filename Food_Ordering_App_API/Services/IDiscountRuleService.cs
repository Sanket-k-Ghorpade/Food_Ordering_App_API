using Food_Ordering_App_API.DTOs.Discount_Rule_DTOs;

namespace Food_Ordering_App_API.Services
{
    public interface IDiscountRuleService
    {
        IEnumerable<DiscountRuleDto> GetAllRules();
        DiscountRuleDto GetRuleById(int id);
        DiscountRuleDto GetActiveRule();
        DiscountRuleDto AddRule(DiscountRuleCreateDto ruleDto);
        DiscountRuleDto UpdateRule(int id, DiscountRuleUpdateDto ruleDto);
        bool DeleteRule(int id);
    }
}
