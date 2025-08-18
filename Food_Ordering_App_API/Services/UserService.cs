using AutoMapper;
using Food_Ordering_App_API.DTOs.User_DTOs;
using Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Repositories;
using Food_Ordering_App_API.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserDto> GetAllUsers()
    {
        var usersQuery = _userRepository.GetAll();
        return _mapper.ProjectTo<UserDto>(usersQuery).ToList();
    }

    public UserDto GetUserById(int id)
    {
        var user = _userRepository.GetById(id);
        return _mapper.Map<UserDto>(user);
    }

    public UserDto RegisterUser(UserCreateDto userDto)
    {
        var user = _mapper.Map<User>(userDto);

        // The password is now saved directly without hashing.
        // user.Password is already mapped from userDto.Password.

        _userRepository.Add(user);
        _userRepository.SaveChanges();

        return _mapper.Map<UserDto>(user);
    }

    public UserDto UpdateUser(int id, UserUpdateDto userDto)
    {
        var userFromRepo = _userRepository.GetById(id);
        if (userFromRepo == null) return null;

        _mapper.Map(userDto, userFromRepo);

        _userRepository.Update(userFromRepo);
        _userRepository.SaveChanges();

        return _mapper.Map<UserDto>(userFromRepo);
    }

    public bool DeleteUser(int id)
    {
        var userFromRepo = _userRepository.GetById(id);
        if (userFromRepo == null) return false;

        _userRepository.Delete(userFromRepo);
        return _userRepository.SaveChanges();
    }

    public bool ChangePassword(int userId, ChangePasswordDto passwordDto)
    {
        var user = _userRepository.GetById(userId);
        if (user == null) return false;

        // Verify the old password with a direct string comparison.
        if (user.Password != passwordDto.OldPassword)
        {
            return false; // Old password does not match
        }

        // Set the new password directly.
        user.Password = passwordDto.NewPassword;
        _userRepository.Update(user);

        return _userRepository.SaveChanges();
    }
}