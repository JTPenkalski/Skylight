using System;
using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEvent"/>
    public record WeatherEvent : BaseWebModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required Weather Weather { get; init; }
        public required DateTime StartDate { get; init; }
        public required DateTime EndDate { get; init; }
        public required WeatherEventStatistics Statistics { get; init; }
        public required WeatherExperience Experience { get; init; }

        public virtual ICollection<Location> Locations { get; init; } = new HashSet<Location>();
        public virtual ICollection<WeatherEventAlert> Alerts { get; init; } = new HashSet<WeatherEventAlert>();
    }
}