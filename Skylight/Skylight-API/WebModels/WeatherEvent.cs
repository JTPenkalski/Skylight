using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEvent"/>
    public record WeatherEvent : BaseWebModel
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public required DateTime StartDate { get; init; }

        [Required]
        public required Weather Weather { get; init; }

        [Required]
        public required WeatherExperience Experience { get; init; }

        [Required]
        public required WeatherEventStatistics Statistics { get; init; }

        [Required]
        public required IEnumerable<Location> Locations { get; init; } // TODO: Consider making this a WeatherEventLocation to make it have audit columns, but then all many to many nav props would need this, so...

        [Required]
        public required IEnumerable<WeatherEventAlert> Alerts { get; init; }
 
        public string? Description { get; init; }

        public DateTime? EndDate { get; init; }
    }
}