using FinancialPortfolio.Application.Handlers.Login;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolio.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginUserHandler, LoginUserHandler>();

            return services;
        }
    }
}
