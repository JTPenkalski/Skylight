namespace Skylight.Forms
{
    /// <summary>
    /// Validation for a <see cref="FormControl"/> that expects a string input.
    /// </summary>
    public class StringFormControlValidation
    {
        /// <summary>
        /// The minimum length of a valid string. 0 by default.
        /// </summary>
        public int MinLength { get; set; } = 0;

        /// <summary>
        /// The maximum length of a valid string. <see cref="int.MaxValue"/> by default.
        /// </summary>
        public int MaxLength { get; set; } = int.MaxValue;
    }
}
