using FinancialPortfolio.Application.DTOs.Auth;
using FinancialPortfolio.Domain.Entities.User;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IJwtService
    {
        AccessTokenDto CreateJWT(User user);
    }
}
