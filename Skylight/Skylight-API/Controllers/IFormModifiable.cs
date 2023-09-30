using Skylight.WebModels;
using System.Threading.Tasks;

namespace Skylight.Controllers.Interfaces
{
    /// <summary>
    /// Indicates that a Web API Controller manages a <see cref="BaseWebModel"/> via HTML form.
    /// Defines the necessary contract for obtaining a <see cref="FormGuide"/>.
    /// </summary>
    public interface IFormModifiable<T> where T : BaseWebModel
    {
        /// <summary>
        /// Gets a form guide based on the current status of the model.
        /// </summary>
        /// <param name="model">The model to base guide validation on.</param>
        /// <param name="context">External context data to contribute to guide validation.</param>
        /// <returns>A new <see cref="FormGuide"/> instance.</returns>
        Task<FormGuide> GetGuide(T model, FormGuideContext context);
    }
}
