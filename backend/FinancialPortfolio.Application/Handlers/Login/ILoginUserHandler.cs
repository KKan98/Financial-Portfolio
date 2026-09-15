using FinancialPortfolio.Application.DTOs.Login;

namespace FinancialPortfolio.Application.Handlers.Login
{
    public interface ILoginUserHandler
    {
        Task<LoginResponseDto?> HandleAsync(LoginRequest request, CancellationToken token);
    }
}
