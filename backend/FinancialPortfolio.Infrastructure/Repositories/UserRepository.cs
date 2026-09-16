using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Domain.Entities.User;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    public class UserRepository(DatabaseContext dbContext) : IUserRepository
    {
        public async Task<User?> GetUserAsync(string email, CancellationToken token)
        {
            var user = await dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email, token);

            return user;
        }   

        public async Task<bool> AddUserAsync(User user, CancellationToken token)
        {
            dbContext.Users.Add(user);

            try
            {
                await dbContext.SaveChangesAsync(token);
                return true;
            }
            catch (DbUpdateException e) when (e.InnerException is PostgresException { SqlState: PostgresErrorCodes.UniqueViolation })
            {
                return false;
            }
        }

        public Task<List<User>> GetAllUsersAsync(CancellationToken token)
        {
            return dbContext.Users
                .AsNoTracking()
                .ToListAsync(token);
        }

        public Task<bool> DoesUserExistAsync(string email, CancellationToken token)
        {
            return dbContext.Users.AnyAsync(x => x.Email == email, token);
        }
    }
}
