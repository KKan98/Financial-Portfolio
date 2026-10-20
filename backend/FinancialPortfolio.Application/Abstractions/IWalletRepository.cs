using FinancialPortfolio.Application.DTOs.Wallet;

namespace FinancialPortfolio.Application.Abstractions
{
    public interface IWalletRepository
    {
        Task<List<WalletResponseDto>> GetAsync(int userId, CancellationToken token);

        Task AddWalletAsync(int userId, string name, CancellationToken token);

        Task<bool> ExistByNameAsync(int userId, string name, CancellationToken token);

        Task<bool> ExistsForUserAsync(int userId, int walletId, CancellationToken token);
    }
}
