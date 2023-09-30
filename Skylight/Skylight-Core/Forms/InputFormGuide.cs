using System;

namespace Skylight.Forms
{
    /// <summary>
    /// Guides how an Input form control should operate on the UI.
    /// </summary>
    public class InputFormGuide : FormGuide
    {
        /// <summary>
        /// Minimum number of characters.
        /// </summary>
        public int? MinLength
        {
            get => _minLength;
            set => _minLength = value.HasValue ? Math.Max(0, value.Value) : value;
        }
        private int? _minLength;

        /// <summary>
        /// Maximum number of characters.
        /// </summary>
        public int? MaxLength
        {
            get => _maxLength;
            set => _maxLength = value.HasValue ? Math.Max(0, value.Value) : value;
        }
        private int? _maxLength;

        /// <summary>
        /// Minimum numeric value.
        /// </summary>
        public int? MinValue
        {
            get => _minValue;
            set => _minValue = value.HasValue ? Math.Max(0, value.Value) : value;
        }
        private int? _minValue;

        /// <summary>
        /// Maximum numeric value.
        /// </summary>
        public int? MaxValue
        {
            get => _maxValue;
            set => _maxValue = value.HasValue ? Math.Max(0, value.Value) : value;
        }
        private int? _maxValue;

        /// <summary>
        /// A Regex that the input value must match.
        /// </summary>
        public string? Regex { get; set; }

        /// <inheritdoc cref="FormGuide(string)"/>
        public InputFormGuide(string name) : base(name) { }

        /// <summary>
        /// Helper method to get a Regex for integer values.
        /// </summary>
        /// <returns>A Regex string.</returns>
        public static string IntegerRegex() => @$"^(-?[1-9]\d*|0)$";

        /// <summary>
        /// Helper method to get a Regex for numeric values.
        /// </summary>
        /// <returns>A Regex string.</returns>
        public static string NumberRegex() => @$"^(-?[1-9]\d*|0)(\.\d+)?$";
    }
}