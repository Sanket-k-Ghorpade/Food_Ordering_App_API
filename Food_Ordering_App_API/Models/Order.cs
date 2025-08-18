using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Ordering_App_API.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        public decimal FinalAmount { get; set; }

        [Required]
        public PaymentMode PaymentMode { get; set; }

        [ForeignKey("DeliveryPartner")]
        public int DeliveryPartnerId { get; set; }
        public virtual DeliveryPartner DeliveryPartner { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }

}
