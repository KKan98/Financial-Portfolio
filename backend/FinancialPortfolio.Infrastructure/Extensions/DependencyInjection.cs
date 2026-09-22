using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Infrastructure.Context;
using FinancialPortfolio.Infrastructure.Repositories;
using FinancialPortfolio.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
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

            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddSingleton<IPasswordHasher, Pbkdf2PasswordHasher>();

            return services;
        }
    }
}
