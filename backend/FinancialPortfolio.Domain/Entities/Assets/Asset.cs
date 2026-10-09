using FinancialPortfolio.Domain.Entities.Wallets;

namespace FinancialPortfolio.Domain.Entities.Assets
{
    public class Asset
    {
        public Guid Id { get; set; }

        public int WalletId { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }

        public decimal BuyingPrice { get; set; }

        public string Currency { get; set; }

        public DateTime Timestamp { get; set; }

        public Wallet Wallet { get; set; } = null!;
    }
}
