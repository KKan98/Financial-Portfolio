using System.Security.Claims;
using FinancialPortfolio.Application.Common;
using FinancialPortfolio.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FinancialPortfolio.Presentation.Controllers
{
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected Result<int> TryGetUserId()
        {
            var claim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(claim, out int userId)) return Errors.InvalidUserIdentity;

            return userId;
        }

        protected IActionResult HandleFailure(Result result)
        {
            if (result.Error == null)
            {
                return Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    detail: "Internal Server Error"
                );
            }

            return result.Error.Type switch
            {
                ErrorType.Conflict => Problem(
                    statusCode: StatusCodes.Status409Conflict,
                    detail: result.Error.Description
                ),
                ErrorType.Validation => Problem(
                    statusCode: StatusCodes.Status400BadRequest,
                    detail: result.Error.Description
                ),
                ErrorType.Unauthorized => Problem(
                    statusCode: StatusCodes.Status401Unauthorized,
                    detail: result.Error.Description
                ),
                _ => Problem(
                    statusCode: StatusCodes.Status500InternalServerError,
                    detail: result.Error.Description
                )
            };
        }
    }
}
