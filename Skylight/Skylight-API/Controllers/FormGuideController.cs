using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skylight.WebModels.Forms;

namespace Skylight.Controllers
{
    /// <summary>
    /// Utility API for managing general <see cref="Forms.FormGuide"/> information.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class FormGuideController : ControllerBase
    {
        /// <summary>
        /// Gets validation messages for UI controls.
        /// </summary>
        /// <returns>An HTTP response for the GET request.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<FormControlValidationMessages> GetValidationMessages()
        {
            return Ok(new FormControlValidationMessages());
        }
    }
}
