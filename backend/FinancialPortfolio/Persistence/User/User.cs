using FinancialPortfolio.Persistence.Roles;

namespace FinancialPortfolio.Persistence.User
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

    }
}
