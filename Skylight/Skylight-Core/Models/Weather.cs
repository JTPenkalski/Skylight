using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a specific type of weather.
    /// </summary>
    public class Weather : BaseIdentifiableModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WeatherEvent> Events { get; set; } = new HashSet<WeatherEvent>();

        /// <summary>
        /// Constructs a new <see cref="Weather"/> instance.
        /// </summary>
        /// <param name="name">The name of the weather type.</param>
        /// <param name="description">A brief description about what the weather type is.</param>
        public Weather(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}