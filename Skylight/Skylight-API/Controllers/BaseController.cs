using Skylight.Web.Models;
using Core = Skylight.Domain.Entities;

namespace Skylight.Controllers
{
    /// <summary>
    /// Represents the shared behavior of all API controllers.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController<TModel, TWebModel>
        : ControllerBase
            where TModel : Core.BaseEntity
            where TWebModel : BaseModel
    {

    }
}