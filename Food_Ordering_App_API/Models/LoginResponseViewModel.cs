namespace Food_Ordering_App_API.Models
{
    public class LoginResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public User User { get; set; }
        public string Token { get; set; }
    }
}
