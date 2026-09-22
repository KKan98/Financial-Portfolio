
namespace FinancialPortfolio.Application.DTOs.Wallet
{
    public record WalletDto
    {
        public required int WalletId { get; set; }

        public required string Name { get; set; } = null!; //read about null!
    }
}
