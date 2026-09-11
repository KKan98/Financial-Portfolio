using FinancialPortfolio.Domain.Enums.Roles;

namespace FinancialPortfolio.Domain.Entities.User
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

    }
}
