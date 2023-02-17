namespace Skylight.Models
{
    /// <summary>
    /// Represents a means of interacting with a <see cref="WeatherEvent"/>.
    /// </summary>
    public class WeatherEventObservationMethod : BaseIdentifiableModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Constructs a new <see cref="WeatherEventObservationMethod"/> instance.
        /// </summary>
        /// <param name="name">The name of the method of observation.</param>
        /// <param name="description">A description of how to observe this way.</param>
        public WeatherEventObservationMethod(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}