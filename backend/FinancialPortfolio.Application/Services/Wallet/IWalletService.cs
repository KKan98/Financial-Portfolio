using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Wallet;

namespace FinancialPortfolio.Application.Services.Wallet
{
    public interface IWalletService
    {
        Task<List<WalletResponseDto>> GetAsync(int userId, CancellationToken token);

        Task<Result> AddAsync(int userId, string name, CancellationToken token);
    }
}