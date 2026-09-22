using FinancialPortfolio.Domain.Entities.Wallets;
using FinancialPortfolio.Domain.Enums.Roles;

namespace FinancialPortfolio.Domain.Entities.Users
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public ICollection<Wallet> Wallets { get; } = new List<Wallet>();

    }
}
