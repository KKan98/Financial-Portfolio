
namespace FinancialPortfolio.Application.DTOs.Wallet
{
    public record WalletResponseDto
    {
        public required int Id { get; init; }

        public required string Name { get; init; }
    }
}
