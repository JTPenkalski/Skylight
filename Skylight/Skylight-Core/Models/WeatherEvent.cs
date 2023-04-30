using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a discrete weather occurence that happened during a <see cref="WeatherExperience"/>.
    /// It is composed of a single weather type and can have multiple associated alerts, numerous affected locations, a total duration, and statistics.
    /// </summary>
    public class WeatherEvent : BaseIdentifiableModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual Weather Weather { get; set; } = null!;
        public virtual WeatherExperience Experience { get; set; } = null!;
        public virtual WeatherEventStatistics Statistics { get; set; } = null!;

        public virtual ICollection<Location> Locations { get; set; } = new List<Location>();
        public virtual ICollection<WeatherEventAlert> Alerts { get; set; } = new List<WeatherEventAlert>();
    }
}