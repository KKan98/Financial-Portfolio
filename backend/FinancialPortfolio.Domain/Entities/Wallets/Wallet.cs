using System.ComponentModel.DataAnnotations;
using FinancialPortfolio.Domain.Entities.Users;

namespace FinancialPortfolio.Domain.Entities.Wallets
{
    public class Wallet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
