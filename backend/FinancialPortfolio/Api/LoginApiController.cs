using FinancialPortfolio.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginApiController(IUserService _userService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            var user = _userService.GetUser(email, password);
            if (user.Count > 0) return Ok(user);
            return NotFound();
        }
    }
}
