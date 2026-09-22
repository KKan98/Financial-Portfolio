using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.DTOs.SignUp;
using FinancialPortfolio.Domain.Entities.Users;
using FinancialPortfolio.Domain.Enums.Roles;

namespace FinancialPortfolio.Application.Services.SignUp
{
    internal sealed class RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) : IRegisterUserHandler
    {
        public async Task<bool> HandleAsync(SignUpRequestDto requestDto, CancellationToken token)
        {
            bool doesUserExist = await userRepository.DoesUserExistAsync(requestDto.Email, token);

            if (doesUserExist) return false;

            string hashedPassword = passwordHasher.HashPassword(requestDto.Password);

            var user = new User
            {
                Email = requestDto.Email,
                Role = Enum.Parse<Role>(requestDto.Role),
                Password = hashedPassword
            };

            await userRepository.AddUserAsync(user, token);

            return true;
        }
    }
}
