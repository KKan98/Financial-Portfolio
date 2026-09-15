using FinancialPortfolio.Domain.Entities.User;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IUserRepository
    {
        public Task<User?> GetUserAsync(string email, CancellationToken token);
        public Task AddUserAsync(string email, string password, string role, CancellationToken token);
        public Task<List<User>> GetAllUsersAsync(CancellationToken token);
    }
}
