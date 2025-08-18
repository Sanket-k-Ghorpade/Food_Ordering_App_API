using Food_Ordering_App_API.DTOs.User_DTOs;

namespace Food_Ordering_App_API.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);
        UserDto RegisterUser(UserCreateDto userDto);
        UserDto UpdateUser(int id, UserUpdateDto userDto);
        bool DeleteUser(int id);
        bool ChangePassword(int userId, ChangePasswordDto passwordDto); // New method
    }

}
