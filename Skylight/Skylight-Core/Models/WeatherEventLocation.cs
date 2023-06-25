using System;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a specific instance of <see cref="Models.Location"/> for a <see cref="WeatherEvent"/>.
    /// </summary>
    public class WeatherEventLocation : BaseIdentifiableModel
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual WeatherEvent Event { get; set; } = null!;
        public virtual Location Location { get; set; } = null!;
    }
}
