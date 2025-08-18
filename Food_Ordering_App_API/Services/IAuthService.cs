using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Services
{
    public interface IAuthService
    {
        LoginResponseViewModel Login(LoginViewModel loginViewModel);

    }
}
