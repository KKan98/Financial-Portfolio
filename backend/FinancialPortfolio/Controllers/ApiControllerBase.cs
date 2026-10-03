using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected bool TryGetUserId(out int userId)
        {
            return int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out userId);
        }
    }
}
