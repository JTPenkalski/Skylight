using System.Threading.Tasks;

namespace Skylight.Forms.Directors
{
    /// <summary>
    /// Determines how the controls on a form should operate to ensure valid data.
    /// This keeps business logic related to form validation unified in the backend.
    /// </summary>
    /// <typeparam name="TModel">The model this form provides input for.</typeparam>
    /// <typeparam name="TFormGuide">The type of form guide to create.</typeparam>
    public interface IFormDirector<TModel, TFormGuide>
    {
        /// <summary>
        /// Gets a <see cref="FormGuide"/> based on the current status of the model
        /// and the additional context data.
        /// </summary>
        /// <param name="model">The model to base guide validation on.</param>
        /// <param name="context">External context data to contribute to guide validation.</param>
        /// <returns>Metadata about how the form should be controlled and displayed.</returns>
        Task<TFormGuide> GetGuideAsync(TModel model, FormGuideContext context);
    }
}