using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.DTOs.Asset
{
    public record AssetGetResponseDto(
        Guid Id,
        string Name,
        decimal Quantity,
        decimal buyingPrice,
        Currency currency,
        DateTime Timestamp);
}
