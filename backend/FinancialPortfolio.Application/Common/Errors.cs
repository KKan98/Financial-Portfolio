using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Application.Common
{
    public static class Errors
    {
        public static Error WalletAlreadyExists { get; } =
            new("WalletAlreadyExists", ErrorType.Conflict, "Wallet already exists.");

        public static Error WalletNotFound { get; } = new("WalletNotFound", ErrorType.NotFound, "Wallet Not Found.");

        public static Error InvalidUserIdentity { get; } =
            new("InvalidUserIdentity", ErrorType.Unauthorized, "The token does not contain a valid user identity.");

        public static Error InvalidCredentials { get; } =
            new("InvalidCredentials", ErrorType.Unauthorized, "Invalid Credentials.");

        public static Error UserNotFound { get; } = new("UserNotFound", ErrorType.NotFound, "User does not exist.");
    }
}