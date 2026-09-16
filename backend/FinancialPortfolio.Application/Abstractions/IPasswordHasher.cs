namespace FinancialPortfolio.Application.Abstractions
{
    public interface IPasswordHasher
    {
        const string dummyHash =
            "56EFA92FE36C0939A48DD7792F866A95BEC6708522E824B24EC78F542DD3B219-407F17B2196B543580E948BCB5C715E7";
        string HashPassword(string password);

        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}
