
namespace FinancialPortfolio.Application.DTOs.Wallet
{
    public record WalletDto
    {
        public required int Id { get; init; }

        public required string Name { get; init; }
    }
}
