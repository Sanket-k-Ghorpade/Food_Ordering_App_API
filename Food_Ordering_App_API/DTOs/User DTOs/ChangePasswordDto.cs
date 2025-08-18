using System.ComponentModel.DataAnnotations;

namespace Food_Ordering_App_API.DTOs.User_DTOs
{
    public class ChangePasswordDto
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
