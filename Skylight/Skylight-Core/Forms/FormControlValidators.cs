using Skylight.Utilities;

namespace Skylight.Forms
{
    /// <summary>
    /// Utility methods for creating and caching commonly reused <see cref="FormControlValidation"/> instances.
    /// </summary>
    public static class FormControlValidators
    {
        /// <summary>
        /// A default <see cref="FormControlValidation"/> instance.
        /// Used for optional values.
        /// </summary>
        public static FormControlValidation Default
        {
            get
            {
                _default ??= new FormControlValidation();
                return _default;
            }
        }
        private static FormControlValidation? _default;

        /// <summary>
        /// A default <see cref="FormControlValidation"/> instance with <see cref="FormControlValidation.Required"/> set to true.
        /// Used for required values.
        /// </summary>
        public static FormControlValidation Required
        {
            get
            {
                _required ??= new FormControlValidation().ToRequired();
                return _required;
            }
        }
        private static FormControlValidation? _required;

        /// <summary>
        /// A default <see cref="FormControlValidation"/> instance with <see cref="FormControlValidation.Pattern"/> restricted to integers.
        /// Used for freeform integer inputs.
        /// </summary>
        public static FormControlValidation Integer
        {
            get
            {
                _integer ??= new FormControlValidation
                {
                    Pattern = RegexUtilities.INTEGER_REGEX
                };
                return _integer;
            }
        }
        private static FormControlValidation? _integer;

        /// <summary>
        /// A default <see cref="FormControlValidation"/> instance with <see cref="FormControlValidation.Pattern"/> restricted to numbers.
        /// Used for freeform integer inputs.
        /// </summary>
        public static FormControlValidation Numeric
        {
            get
            {
                _numeric ??= new FormControlValidation
                {
                    Pattern = RegexUtilities.NUMBER_REGEX
                };
                return _numeric;
            }
        }
        private static FormControlValidation? _numeric;

        #region Extensions
        /// <summary>
        /// Enables the <see cref="FormControlValidation.Required"/> property.
        /// </summary>
        /// <returns>The same <see cref="FormControlValidation"/> instance.</returns>
        public static FormControlValidation ToRequired(this FormControlValidation validation)
        {
            validation.Required = true;
            return validation;
        }
        #endregion
    }
}
