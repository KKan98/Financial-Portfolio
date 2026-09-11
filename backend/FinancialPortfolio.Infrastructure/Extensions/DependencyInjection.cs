using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolio.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
