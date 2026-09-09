using FinancialPortfolio.Persistence.Roles;

namespace FinancialPortfolio.Persistence.Login
{
    public class LoginResponseDto(int id, string email, Role role, string jwt, long expiresAt)
    {
        public int Id { get; set; } = id;
        public string Email { get; set; } = email;
        public Role Role { get; set; } = role;
        public string Jwt { get; set; } = jwt;
        public long ExpiresAt { get; set; } = expiresAt;
    }
}
