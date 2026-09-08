using FinancialPortfolio.Persistence.Roles;

namespace FinancialPortfolio.Services.AuthService
{
    public interface IAuthService
    {
        public bool IsAuthenticated(string email, string password, Role role);
        public Role? GetUserRole(string email, string password);
    }
}
