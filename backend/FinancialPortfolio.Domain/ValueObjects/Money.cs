using FinancialPortfolio.Domain.Enums;

namespace FinancialPortfolio.Domain.ValueObjects
{
    public readonly record struct Money
    {

        public decimal Amount { get; init; }

        public Currency Currency { get; init; }

        public Money(decimal amount, Currency currency)
        {
            if (!Enum.IsDefined(currency)) //result pattern?
            {
                throw new ArgumentOutOfRangeException($"{currency} does not exist. Available currencies are: {string.Join(", ", Enum.GetValues<Currency>())}");
            }

            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);

            Amount = amount;
            Currency = currency;
        }

        public static void EnsureSameCurrency(Money left, Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException($"Cannot operate on {left.Currency} and {right.Currency}");
        }
    }
}
