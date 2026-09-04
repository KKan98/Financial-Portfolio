using FinancialPortfolio.Persistence.User;

namespace FinancialPortfolio.Services.Users
{
    public interface IUserService
    {
        public User GetUser(string email, string password);
    }
}
