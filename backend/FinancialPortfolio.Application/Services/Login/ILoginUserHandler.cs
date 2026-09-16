using FinancialPortfolio.Application.DTOs.Login;

namespace FinancialPortfolio.Application.Services.Login
{
    public interface ILoginUserHandler
    {
        Task<LoginResponseDto?> HandleAsync(LoginRequestDto requestDto, CancellationToken token);
    }
}
