using FinancialPortfolio.Application.Abstractions;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Application.DTOs.Login;
using FinancialPortfolio.Application.Services.Login;
using FinancialPortfolio.Domain.Entities;
using NSubstitute;
using FinancialPortfolio.Application.DTOs.Auth;
using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.Tests.Services.Login
{
    public class LoginUserHandlerTests
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;
        private readonly LoginUserHandler _handler;
        private readonly LoginRequestDto _loginRequest = new LoginRequestDto("user1@email.com", "secretPassword");

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
            //Arrange
            _repository.GetUserAsync(_loginRequest.Email, Arg.Any<CancellationToken>())
                .Returns((User?)null);

            //Act
            var result = await _handler.HandleAsync(_loginRequest, CancellationToken.None);

            //Assert
            Assert.Equal(Errors.InvalidCredentials, result.Error!);
            Assert.True(result.IsFailure);

            _jwtService.DidNotReceive()
                .CreateJWT(Arg.Any<User>());

            _passwordHasher.Received(1)
                .VerifyHashedPassword(IPasswordHasher.dummyHash, _loginRequest.Password);
        }

        [Fact]
        public async Task HandleAsync_ValidCredentials_ReturnsLoginResponseDto()
        {
            //Arrange
            var user = new User
            {
                Id = 1,
                Email = _loginRequest.Email,
                Password = "Hashed Password",
                Role = Role.Administrator
            };

            _repository.GetUserAsync(_loginRequest.Email, Arg.Any<CancellationToken>())
                .Returns(user);

            _passwordHasher.VerifyHashedPassword(user.Password, _loginRequest.Password)
                .Returns(true);

            var accessToken = new AccessTokenDto("jwt", 10201023);

            _jwtService.CreateJWT(user)
                .Returns(accessToken);

            var loginResponseDto = new LoginResponseDto(
                user.Id,
                user.Email, 
                user.Role, 
                accessToken.Jwt,
                accessToken.ExpiresUnixEpoch);

            //Act
            var result = await _handler.HandleAsync(_loginRequest, CancellationToken.None);

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(loginResponseDto, result.Value);

        }
    }
}