using FinancialPortfolio.Application.Services.Login;
using FinancialPortfolio.Application.Services.SignUp;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialPortfolio.Application.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginUserHandler, LoginUserHandler>();
            services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();

            return services;
        }
    }
}
