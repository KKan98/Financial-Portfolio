using FinancialPortfolio.Persistence.Users;

namespace FinancialPortfolio.Services.Users
{
    public interface IUserService
    {
        public List<User> GetUser(string email, string password);
    }
}
