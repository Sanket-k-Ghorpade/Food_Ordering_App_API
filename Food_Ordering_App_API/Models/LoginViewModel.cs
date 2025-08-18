using System.ComponentModel.DataAnnotations;

namespace Food_Ordering_App_API.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter the User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter the password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
