using System.ComponentModel.DataAnnotations;

namespace FinancialPortfolio.Domain.Entities
{
    public sealed class Wallet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public User User { get; set; } = null!;

        public ICollection<Stock> Assets { get; } = new List<Stock>();
    }
}
