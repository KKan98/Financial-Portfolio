using FinancialPortfolio.Persistence.User;

namespace FinancialPortfolio.Services.Users
{
    public interface IUserService
    {
        public User? GetUser(string email, string password);
        public void AddUser(string email, string password, string role);
        public List<User?> GetAllUsers();
    }
}
