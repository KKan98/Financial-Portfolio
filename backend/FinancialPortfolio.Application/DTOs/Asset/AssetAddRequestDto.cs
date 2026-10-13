using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.DTOs.Asset
{
    public record AssetAddRequestDto(int WalletId, string Name, decimal Quantity, decimal BuyingPrice, Currency Currency);
}
