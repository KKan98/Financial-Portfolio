using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.SignUp;

namespace FinancialPortfolio.Application.Services.SignUp
{
    public interface IRegisterUserHandler
    {
        Task<Result> HandleAsync(SignUpRequestDto requestDto, CancellationToken token);
    }
}
