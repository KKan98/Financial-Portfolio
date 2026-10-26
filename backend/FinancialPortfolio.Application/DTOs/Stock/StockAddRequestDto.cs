using System.Text.Json.Serialization;
using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.DTOs.Stock
{
    public record StockAddRequestDto(
        int WalletId, 
        string Symbol, 
        string MIC,
        decimal Quantity, 
        decimal BuyingPrice, 
        [property: JsonConverter(typeof(JsonStringEnumConverter<Currency>))] Currency Currency);
}
