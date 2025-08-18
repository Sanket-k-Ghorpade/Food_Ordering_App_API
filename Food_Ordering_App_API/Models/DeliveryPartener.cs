using System.ComponentModel.DataAnnotations;

namespace Food_Ordering_App_API.Models
{
    public class DeliveryPartner
    {
        [Key]
        public int DeliveryPartnerId { get; set; }

        public string PartnerName { get; set; }
        public string PartnerPhone { get; set; }
        public bool IsAvailable { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}
