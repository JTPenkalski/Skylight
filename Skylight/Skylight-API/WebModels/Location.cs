using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.Location"/>
    public class Location : BaseWebModel
    {
        public required string City { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }

        public virtual ICollection<WeatherEvent> Events { get; set; } = new HashSet<WeatherEvent>();
    }
}