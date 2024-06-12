using Microsoft.AspNetCore.Authorization;

namespace Skylight.Controllers;

/// <summary>
/// Represents the shared behavior of all API controllers.
/// Primarily used for ensuring all dependencies and common functionality is consolidated.
/// </summary>
[ApiController]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
public abstract class BaseController : ControllerBase
{

}
