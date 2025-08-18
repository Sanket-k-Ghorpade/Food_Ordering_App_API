namespace Food_Ordering_App_API.DTOs.User_DTOs
{
    public class UserUpdateDto
    {
        public string UserFullName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string UserAddress { get; set; }
        public int RoleId { get; set; }
    }
}
