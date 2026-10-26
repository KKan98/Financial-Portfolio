using System.Text.Json.Serialization;
using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.DTOs.Stock
{
    public record AssetGetResponseDto(
        Guid Id,
        string Name,
        decimal Quantity,
        decimal buyingPrice,
        [property: JsonConverter(typeof(JsonStringEnumConverter<Currency>))] Currency currency,
        DateTime Timestamp);
}
