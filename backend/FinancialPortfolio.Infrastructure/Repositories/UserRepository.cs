using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Domain.Entities.User;
using FinancialPortfolio.Domain.Enums.Roles;
using FinancialPortfolio.Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    public class UserRepository(DatabaseContext _dbContext, IPasswordHasher<User> _passwordHasher) : IUserRepository
    {
        public async Task<User?> GetUserAsync(string email, string password, CancellationToken token)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email, token);

            if (user is null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return result == PasswordVerificationResult.Success ? user : null;
        }

        public async Task AddUserAsync(string email, string password, string role, CancellationToken token)
        {
            if (await DoesUserExist(email, token)) throw new Exception("User already exist.");

            var user = new User
            {
                Email = email,
                Role = Enum.Parse<Role>(role)
            };

            string hashedPassword = _passwordHasher.HashPassword(user, password);

            user.Password = hashedPassword;

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(token);
        }

        public Task<List<User>> GetAllUsersAsync(CancellationToken token)
        {
            return _dbContext.Users
                .AsNoTracking()
                .ToListAsync(token);
        }

        private Task<bool> DoesUserExist(string email, CancellationToken token)
        {
            return _dbContext.Users.AnyAsync(x => x.Email == email, token);
        }
    }
}
