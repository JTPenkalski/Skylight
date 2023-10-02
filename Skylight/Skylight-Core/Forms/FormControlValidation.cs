namespace Skylight.Forms
{
    /// <summary>
    /// Base valiation for any <see cref="FormControl"/>.
    /// </summary>
    public class FormControlValidation
    {
        /// <summary>
        /// If this control is required to have a value. False by default.
        /// </summary>
        public bool Required { get; set; } = false;

        /// <summary>
        /// The Regular Expression pattern this input must match. Null by default.
        /// </summary>
        public string? Pattern { get; set; } = null;

        /// <summary>
        /// Extra validations to use if this control expects a string value.
        /// </summary>
        public StringFormControlValidation? StringValidation { get; set; } = null;

        /// <summary>
        /// Extra validations to use if this control expects a numeric value.
        /// </summary>
        public NumericFormControlValidation? NumericValidation { get; set; } = null;

        /// <summary>
        /// Extra validations to use if this control expects a DateTime value.
        /// </summary>
        public DateTimeOffsetFormControlValidation? DateTimeValidation { get; set; } = null;

        /// <summary>
        /// Extra validations to use if this control expects an array value.
        /// </summary>
        public ArrayFormControlValidation? ArrayValidation { get; set; } = null;
    }
}
