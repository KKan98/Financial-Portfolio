using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Login;

namespace FinancialPortfolio.Application.Services.Login
{
    public interface ILoginUserHandler
    {
        Task<Result<LoginResponseDto?>> HandleAsync(LoginRequestDto requestDto, CancellationToken token);
    }
}
