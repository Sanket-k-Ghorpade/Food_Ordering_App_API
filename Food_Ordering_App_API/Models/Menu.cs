using System.ComponentModel.DataAnnotations;

namespace Food_Ordering_App_API.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Menu Name is Required")]
        public string MenuName { get; set; }

        public virtual ICollection<MenuItem>? MenuItems { get; set; }
    }
}
