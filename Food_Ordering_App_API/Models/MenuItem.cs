using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Ordering_App_API.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }

        [Required(ErrorMessage = "Menu item name is required")]
        public string MenuItemName { get; set; }

        [Required(ErrorMessage = "Menu item price is required")]
        public decimal MenuItemPrice { get; set; }

        [ForeignKey("Menu")]
        public int MenuId { get; set; }

        public virtual Menu? Menu { get; set; }
    }
}
