using Food_Ordering_App_API.Models;

namespace Food_Ordering_App_API.Repositories
{
    public interface IAuthRepository
    {
        LoginResponseViewModel Login(LoginViewModel loginViewModel);
    }
}
