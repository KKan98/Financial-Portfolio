using FinancialPortfolio.Application.DTOs.SignUp;

namespace FinancialPortfolio.Application.Services.SignUp
{
    public interface IRegisterUserHandler
    {
        Task<bool> HandleAsync(SignUpRequestDto requestDto, CancellationToken token);
    }
}
