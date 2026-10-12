using FinancialPortfolio.Domain.Entities.Wallets;
using FinancialPortfolio.Domain.ValueObjects;

namespace FinancialPortfolio.Domain.Entities.Assets
{
    public class Asset
    {
        public Guid Id { get; set; }

        public required int WalletId { get; set; }

        public required string Name { get; set; }

        public required decimal Quantity { get; set; }

        public required Money BuyingPrice { get; set; }

        public DateTime Timestamp { get; set; }

        public Wallet Wallet { get; set; } = null!;
    }
}
