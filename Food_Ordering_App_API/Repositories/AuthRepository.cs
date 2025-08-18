using Food_Ordering_App_API.Data.Food_Ordering_App_API.Models;
using Food_Ordering_App_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Food_Ordering_App_API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly FoodOrderingAppDbContext _context;

        public AuthRepository(FoodOrderingAppDbContext context)
        {
            _context = context;
        }

        LoginResponseViewModel IAuthRepository.Login(LoginViewModel login)
        {
            var user = _context.Users.Include(u => u.UserRole)
                .FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);

            LoginResponseViewModel response;
            if (user != null)
            {
                //GenerateToken
                response = new LoginResponseViewModel { IsSuccess = true, User = user, Token = "" };
                return response;
            }
            response = new LoginResponseViewModel { IsSuccess = false, User = null, Token = "" };
            return response;
        }
    }
}
