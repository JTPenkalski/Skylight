using Microsoft.AspNetCore.Mvc;
using Skylight.WebModels.Forms;
using Skylight.WebModels.Models;
using System.Threading.Tasks;

namespace Skylight.Controllers.Interfaces
{
    /// <summary>
    /// Indicates that a Web API Controller manages a <see cref="BaseWebModel"/> via some UI form.
    /// Defines the necessary contract for obtaining a <see cref="FormGuide"/>.
    /// </summary>
    /// <typeparam name="TModel">The type of the <see cref="BaseWebModel"/> this guide is based on.</typeparam>
    /// <typeparam name="TGuide">The type of <see cref="FormGuide"/> to be returned.</typeparam>
    public interface IFormModifiable<TModel, TGuide>
        where TModel : BaseWebModel
        where TGuide : FormGuide
    {
        /// <summary>
        /// Gets a <see cref="FormGuide"/> based on the current status of the model
        /// and the additional context data.
        /// </summary>
        /// <param name="request">The request data.</param>
        /// <returns>Metadata about how the form should be controlled and displayed.</returns>
        Task<ActionResult<TGuide>> GetFormGuide(FormGuideRequest<TModel> request);
    }
}
