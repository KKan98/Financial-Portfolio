using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Domain.Entities
{
    public sealed class User
    {
        public int Id { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public Role Role { get; set; }

        public ICollection<Wallet> Wallets { get; } = new List<Wallet>();

    }
}
