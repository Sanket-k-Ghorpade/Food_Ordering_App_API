namespace Food_Ordering_App_API.DTOs.Discount_Rule_DTOs
{
    public class DiscountRuleUpdateDto
    {
        public decimal MinOrderValue { get; set; }
        public decimal FlatDiscount { get; set; }
    }
}
