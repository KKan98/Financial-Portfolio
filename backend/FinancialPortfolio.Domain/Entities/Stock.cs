using FinancialPortfolio.Domain.ValueObjects;

namespace FinancialPortfolio.Domain.Entities
{
    public sealed class Stock
    {
        public Guid Id { get; set; }

        public required int WalletId { get; set; }

        public required string Symbol { get; set; }

        public required string MIC { get; set; }

        public required decimal Quantity { get; set; }

        public required Money BuyingPrice { get; set; }

        public DateTime Timestamp { get; set; }

        public Wallet Wallet { get; set; } = null!;
    }
}
