using FinancialPortfolio.Domain.Entities.User;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IUserRepository
    {
        public User? GetUser(string email, string password);
        public void AddUser(string email, string password, string role);
        public List<User?> GetAllUsers();
    }
}
