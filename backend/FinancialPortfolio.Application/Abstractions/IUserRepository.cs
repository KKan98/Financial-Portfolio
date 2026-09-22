using FinancialPortfolio.Domain.Entities.Users;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IUserRepository
    {
        public Task<User?> GetUserAsync(string email, CancellationToken token);
        public Task<bool> AddUserAsync(User user, CancellationToken token);
        public Task<bool> DoesUserExistAsync(string email, CancellationToken token);
    }
}
