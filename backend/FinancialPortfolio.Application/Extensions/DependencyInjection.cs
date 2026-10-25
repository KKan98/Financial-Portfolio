using FinancialPortfolio.Application.Services.Asset;
using FinancialPortfolio.Application.Services.Login;
using FinancialPortfolio.Application.Services.MarketData;
using FinancialPortfolio.Application.Services.SignUp;
using FinancialPortfolio.Application.Services.Wallet;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolio.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginUserHandler, LoginUserHandler>();
            services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IAssetService, AssetService>();
            services.AddScoped<IMarketDataService, MarketDataService>();
            services.AddScoped<IMarketDataService, MarketDataService>();

            return services;
        }
    }
}
