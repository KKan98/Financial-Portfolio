using FinancialPortfolio.Application.DTOs.Wallet;

namespace FinancialPortfolio.Application.Services.Wallet
{
    public interface IWalletService
    {
        Task<List<WalletDto>> GetAsync(int userId, CancellationToken token);

        Task<bool> HandleAsync(int userId, string name, CancellationToken token);
    }
}