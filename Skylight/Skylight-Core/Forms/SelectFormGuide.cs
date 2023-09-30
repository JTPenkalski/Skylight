using System.Collections.Generic;
using System.Linq;

namespace Skylight.Forms
{
    /// <summary>
    /// Guides how a Select/Dropdown form control should operate on the UI.
    /// </summary>
    public class SelectFormGuide<T> : FormGuide
    {
        public IEnumerable<SelectOption<T>> Options { get; set; } = Enumerable.Empty<SelectOption<T>>();

        /// <inheritdoc cref="FormGuide(string)"/>
        public SelectFormGuide(string name) : base(name) { }
    }

    /// <summary>
    /// Represents an option in a Select/Dropdown form control.
    /// </summary>
    public class SelectOption<T>
    {
        public string Name { get; }
        public T Value { get; }

        public SelectOption(string name, T value)
        {
            Name = name;
            Value = value;
        }
    }
}