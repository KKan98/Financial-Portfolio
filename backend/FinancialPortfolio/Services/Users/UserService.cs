using FinancialPortfolio.Persistence.Users;

namespace FinancialPortfolio.Services.Users
{
    public class UserService : IUserService
    {
        public List<User> InMemoryUsers =
        [
            new(){ Id = 1, Email = "user1@email.com", Password = "1" },
            new(){ Id = 2, Email = "user2@email.com", Password = "2" },
            new(){ Id = 3, Email = "user3@email.com", Password = "3" },
            new(){ Id = 4, Email = "user4@email.com", Password = "4" }
        ];

        public List<User> GetUser(string email, string password)
        {
            return InMemoryUsers.Where(x => x.Email == email && x.Password == password).ToList();
        }
    }
}
