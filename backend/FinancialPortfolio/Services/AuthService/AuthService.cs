using FinancialPortfolio.Persistence.Roles;
using FinancialPortfolio.Services.Users;

namespace FinancialPortfolio.Services.AuthService
{
    public class AuthService(IUserService _userService) : IAuthService
    {
        public bool IsAuthenticated(string email, string password, Role role)
        {
            var user = _userService.GetUser(email, password);
            if (user.Role == role) return true;
            return false;
        }

        public Role? GetUserRole(string email, string password)
        {
            var userRole = _userService.GetUser(email, password)?.Role;
            return userRole;
        }
    }
}
