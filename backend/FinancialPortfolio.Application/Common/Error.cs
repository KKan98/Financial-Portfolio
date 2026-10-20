using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.Common
{
    public record Error(string Id, ErrorType Type, string Description);
}
