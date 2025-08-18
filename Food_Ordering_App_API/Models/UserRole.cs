using System.ComponentModel.DataAnnotations;

namespace Food_Ordering_App_API.Models
{
    public enum Role { ADMIN, MEMBER }
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Role is Required")]
        public Role Role { get; set; }

        public virtual IEnumerable<User>? Users { get; set; }
    }
}
