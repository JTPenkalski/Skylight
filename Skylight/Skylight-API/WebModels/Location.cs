using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.Location"/>
    public record Location : BaseWebModel
    {
        public required string City { get; init; }
        public required string ZipCode { get; init; }
        public required string Country { get; init; }

        public virtual ICollection<WeatherEvent> Events { get; init; } = new HashSet<WeatherEvent>();
    }
}