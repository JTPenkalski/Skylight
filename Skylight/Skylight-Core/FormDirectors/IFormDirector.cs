using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Forms
{
    /// <summary>
    /// Determines how the controls on a form should operate to ensure valid data.
    /// </summary>
    /// <typeparam name="T">The model this form provides input for.</typeparam>
    public interface IFormDirector<T>
    {
        /// <summary>
        /// Gets the <see cref="FormGuide"/> for this model, based on the current state of the model.
        /// </summary>
        /// <param name="model">The current value of the model.</param>
        /// <returns>Metadata about how the current form should now be controlled.</returns>
        Task<IEnumerable<FormGuide>> GetGuide(T model);
    }
}