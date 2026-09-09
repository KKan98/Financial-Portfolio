namespace FinancialPortfolio.Persistence.Login
{
    public class LoginResponse
    {
        public LoginResponse(string jwt)
        {
            Jwt = jwt;
        }
        public string Jwt { get; set; }
    }
}
