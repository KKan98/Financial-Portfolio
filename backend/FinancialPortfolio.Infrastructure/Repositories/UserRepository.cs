using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Domain.Entities.User;
using FinancialPortfolio.Domain.Enums.Roles;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    public class UserRepository(DatabaseContext _dbContext) : IUserRepository
    {
        public async Task<User?> GetUserAsync(string email, string password, CancellationToken token)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password, token);

            return user;
        }

        public async Task AddUserAsync(string email, string password, string role, CancellationToken token)
        {
            var user = new User
            {
                Email = email,
                Password = password, //TODO: HASH IT
                Role = Enum.Parse<Role>(role)
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(token);
        }

        public Task<List<User>> GetAllUsersAsync(CancellationToken token)
        {
            return _dbContext.Users
                .AsNoTracking()
                .ToListAsync(token);
        }
    }
}
