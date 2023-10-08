namespace Skylight.Forms
{
    /// <summary>
    /// Validation for a <see cref="FormControl"/> that expects a numeric input.
    /// </summary>
    public class NumericFormControlValidation
    {
        /// <summary>
        /// The minimum value of a valid input. 0 by default.
        /// </summary>
        public float MinValue { get; set; } = 0f;

        /// <summary>
        /// The maximum value of a valid input. <see cref="float.MaxValue"/> by default.
        /// </summary>
        public float MaxValue { get; set; } = float.MaxValue;
    }
}
