using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Domain.Entities.User;
using FinancialPortfolio.Domain.Enums.Roles;

namespace FinancialPortfolio.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User?> InMemoryUsers =
        [
            new(){ Id = 1, Email = "user1@email.com", Password = "1", Role = Role.None},
            new(){ Id = 2, Email = "user2@email.com", Password = "2", Role = Role.Administrator },
            new(){ Id = 3, Email = "user3@email.com", Password = "3", Role = Role.Basic }
        ];

        public User? GetUser(string email, string password)
        {
            return InMemoryUsers.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void AddUser(string email, string password, string role)
        {
            int id = InMemoryUsers.Count + 1;
            InMemoryUsers.Add(new(){Id = id, Email = email, Password = password, Role = Enum.Parse<Role>(role)});
        }

        public List<User?> GetAllUsers()
        {
            return InMemoryUsers;
        }
    }
}
