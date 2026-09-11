using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolio.Infrastructure.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("The connection string DefaultConnection has not been initialized.");
            }

            services.AddNpgsqlDataSource(connectionString);

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
