using FinancialPortfolio.Domain.Enums;
using System.Text.Json.Serialization;

namespace FinancialPortfolio.Application.DTOs.Asset
{
    public record AssetGetResponseDto(
        Guid Id,
        string Name,
        decimal Quantity,
        decimal buyingPrice,
        [property: JsonConverter(typeof(JsonStringEnumConverter<Currency>))] Currency currency,
        DateTime Timestamp);
}
