using System.ComponentModel.DataAnnotations;

namespace Food_Ordering_App_API.Models
{
    public class DiscountRule
    {
        [Key]
        public int DiscountRuleId { get; set; }
        public decimal MinOrderValue { get; set; }
        public decimal FlatDiscount { get; set; }
    }
}
