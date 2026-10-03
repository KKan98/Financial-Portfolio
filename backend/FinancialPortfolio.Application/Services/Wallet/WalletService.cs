using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.Wallet;

namespace FinancialPortfolio.Application.Services.Wallet
{
    internal class WalletService(IWalletRepository walletRepository) : IWalletService
    {
        public Task<List<WalletDto>> GetAsync(int userId, CancellationToken token)
        {
            return walletRepository.GetAsync(userId, token);
        }

        public async Task<bool> HandleAsync(int userId, string name, CancellationToken token)
        {
            bool walletExists = await walletRepository.FindWalletAsync(userId, name, token);

            if (walletExists) return false;

            return await walletRepository.AddWalletAsync(userId, name, token);
        }
    }
}