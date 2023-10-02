namespace Skylight.Forms
{
    /// <summary>
    /// A name/value pair for a potential <see cref="FormControl{T}"/> value.
    /// </summary>
    /// <remarks>
    /// Helpful when a <see cref="FormControl{T}"/> may contain pre-defined values, such as an HTML select element.
    /// </remarks>
    public class FormControlValue<T>
    {
        /// <summary>
        /// The display name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The actual value.
        /// </summary>
        public T Value { get; set; }

        public FormControlValue(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }
}
