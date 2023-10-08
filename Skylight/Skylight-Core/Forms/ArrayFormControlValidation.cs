namespace Skylight.Forms
{
    /// <summary>
    /// Validation for a <see cref="FormControl"/> that expects an array of inputs.
    /// </summary>
    public class ArrayFormControlValidation
    {
        /// <summary>
        /// The minimum number of elements in this array for a valid input. 0 by default.
        /// </summary>
        public int MinElements { get; set; } = 0;

        /// <summary>
        /// The maximum number of elements in this array for a valid input. <see cref="int.MaxValue"/> by default.
        /// </summary>
        public int MaxElements { get; set; } = int.MaxValue;
    }
}
