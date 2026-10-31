using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Login;
using FinancialPortfolio.Application.Services.Login;
using FinancialPortfolio.Domain.Entities;
using NSubstitute;

namespace FinancialPortfolio.Application.Tests.Services.Login
{
    public class LoginUserHandlerTests
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;
        private readonly LoginUserHandler _handler;

        public LoginUserHandlerTests()
        {
            _repository = Substitute.For<IUserRepository>();
            _passwordHasher = Substitute.For<IPasswordHasher>();
            _jwtService = Substitute.For<IJwtService>();
            _handler = new LoginUserHandler(_repository, _passwordHasher, _jwtService);
        }

        [Fact]
        public async Task HandleAsync_InvalidCredentials_ReturnInvalidCredentialsError()
        {
            var loginRequestDto = new LoginRequestDto("user1@email.com", "secretPassword");

            _repository.GetUserAsync(loginRequestDto.Email, Arg.Any<CancellationToken>())
                .Returns((User?)null);


            var result = await _handler.HandleAsync(loginRequestDto, CancellationToken.None);

            
            Assert.Equal(Errors.InvalidCredentials, result.Error!);
            Assert.True(result.IsFailure);

            _jwtService.DidNotReceive()
                .CreateJWT(Arg.Any<User>());

            _passwordHasher.Received(1)
                .VerifyHashedPassword(IPasswordHasher.dummyHash, loginRequestDto.Password);
        }

        //[Fact]
        //public async Task HandleAsync_ValidCredentials_ReturnsLoginResponseDto()
        //{

        //}
    }
}
