using Microsoft.AspNetCore.Mvc;

namespace Skylight.API.Controllers;

/// <summary>
/// Represents the shared behavior of all API controllers.
/// Primarily used for ensuring all dependencies and common functionality is consolidated.
/// </summary>
[ApiController]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status403Forbidden)]
[ProducesResponseType(StatusCodes.Status429TooManyRequests)]
public abstract class BaseController : ControllerBase;
