using FinancialPortfolio.Application.DTOs.Asset;

namespace FinancialPortfolio.Application.Services.Asset
{
    public interface IAssetService
    {
        Task<List<AssetGetResponseDto>> GetAsync(int userId, AssetGetRequestDto request, CancellationToken token);

        Task AddAsync(int userId, AssetAddRequestDto addRequest, CancellationToken token);
    }
}
