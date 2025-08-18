using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Food_Ordering_App_API.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter the Full Name")]
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "Enter the User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression("^[0-9]{3}-[0-9]{3}$", ErrorMessage = "The Phone number must be in the format: xxx-xxx")]
        public string UserPhone { get; set; }

        [Required(ErrorMessage = "User Email is Required")]
        [EmailAddress(ErrorMessage = "Email not in proper format")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "User Address is Required")]
        public string UserAddress { get; set; }

        [ForeignKey("UserRole")]
        public int RoleId { get; set; }

        public virtual UserRole? UserRole { get; set; }
    }
}
