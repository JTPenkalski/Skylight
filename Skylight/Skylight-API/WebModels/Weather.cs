using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.Weather"/>
    public record Weather : BaseWebModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }

        public virtual ICollection<WeatherEvent> Events { get; init; } = new HashSet<WeatherEvent>();
    }
}