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
        public string Name { get; set; }
        public string Description { get; set; }
        public Weather Weather { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WeatherExperience Experience { get; set; } = null!;
        public WeatherEventStatistics Statistics { get; set; } = null!;

        public virtual ICollection<Location> Locations { get; set; } = new HashSet<Location>();
        public virtual ICollection<WeatherEventAlert> Alerts { get; set; } = new HashSet<WeatherEventAlert>();

        /// <summary>
        /// Constructs a new <see cref="WeatherEvent"/> instance.
        /// </summary>
        /// <param name="name">The name of the event.</param>
        /// <param name="description">A brief description or notes about the event.</param>
        /// <param name="startDate">The earliest recorded time of the event.</param>
        public WeatherEvent(string name, string description, DateTime startDate)
        {
            Name = name;
            Description = description;
            StartDate = startDate;
        }
    }
}