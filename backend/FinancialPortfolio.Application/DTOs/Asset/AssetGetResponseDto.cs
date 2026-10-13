using FinancialPortfolio.Domain.ValueObjects;

namespace FinancialPortfolio.Application.DTOs.Asset
{
    public record AssetGetResponseDto(string Name, decimal Quantity, Money BuyingPrice, DateTime Timestamp);
}
