using FinancialPortfolio.Persistence.Roles;
using FinancialPortfolio.Persistence.User;

namespace FinancialPortfolio.Services.Users
{
    public class UserService : IUserService
    {
        public List<User?> InMemoryUsers =
        [
            new(){ Id = 1, Email = "user1@email.com", Password = "1", Role = Role.None},
            new(){ Id = 2, Email = "user2@email.com", Password = "2", Role = Role.Administrator },
            new(){ Id = 3, Email = "user3@email.com", Password = "3", Role = Role.Basic },
            new(){ Id = 4, Email = "user4@email.com", Password = "4", Role = Role.Pro }
        ];

        public User GetUser(string email, string password)
        {
            return InMemoryUsers.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
    }
}
