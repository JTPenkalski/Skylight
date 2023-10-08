using System.Collections.Generic;

namespace Skylight.Forms
{
    /// <summary>
    /// Base container for metadata that dictates how a specific UI control should function.
    /// Used within a <see cref="FormGuide"/>.
    /// </summary>
    public class FormControlGuide<T>
    {
        /// <summary>
        /// The necessary validators to use when submitting a form request.
        /// </summary>
        public required FormControlValidation Validation { get; set; }

        /// <summary>
        /// If this control is displayed, but readonly. False by default.
        /// </summary>
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// If this control is hidden from the display. False by default.
        /// </summary>
        public bool Hidden { get; set; } = false;

        /// <summary>
        /// The default value of this control, if any. Null by default.
        /// </summary>
        public T? DefaultValue { get; set; } = default;

        /// <summary>
        /// The pre-defined values this control should provide, if any. Null by default.
        /// </summary>
        public IEnumerable<FormControlValue<T>>? SuppliedValues { get; set; } = null;
    }
}

