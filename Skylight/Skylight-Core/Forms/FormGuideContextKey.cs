using System.Collections.Generic;

namespace Skylight.Forms
{
    /// <summary>
    /// The identifier for a specific piece of data that may optionally be supplied in a <see cref="FormGuideContext"/>.
    /// </summary>
    public enum FormGuideContextKey
    {
        /// <summary>
        /// Indicates that an <see cref="IEnumerable{T}"/> of <see cref="FormControlGuide{T}"/> instances
        /// is only represented by a single <see cref="FormControlGuide{T}"/> on the UI, for simplicity.
        /// For example, an HTML select element with multi-select enabled.
        /// </summary>
        /// <remarks>
        /// Key Value: An enumerable of the controls' names this applies to.
        /// </remarks>
        UnifiedEnumerableControls
    }
}
