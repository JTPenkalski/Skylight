using System;

namespace Skylight.Forms
{
    /// <summary>
    /// Validation for a <see cref="FormControl"/> that expects a date input.
    /// </summary>
    public class DateTimeOffsetFormControlValidation
    {
        /// <summary>
        /// The minimum value of a valid input. <see cref="DateTimeOffset.MinValue"/> by default.
        /// </summary>
        public DateTimeOffset MinValue { get; set; } = DateTimeOffset.MinValue;

        /// <summary>
        /// The maximum value of a valid input. <see cref="DateTimeOffset.MaxValue"/> by default.
        /// </summary>
        public DateTimeOffset MaxValue { get; set; } = DateTimeOffset.MaxValue;
    }
}
