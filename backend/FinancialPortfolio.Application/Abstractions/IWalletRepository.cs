using FinancialPortfolio.Application.DTOs.Wallet;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IWalletRepository
    {
        Task<List<WalletDto>> GetAsync(int userId, CancellationToken token);

        Task<bool> AddWalletAsync(int userId, string name, CancellationToken token);
    }
}
