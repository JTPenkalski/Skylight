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
        public required Weather Weather { get; init; }
        
        [Required]
        public required DateTime StartDate { get; init; }
        
        [Required]
        public required WeatherEventStatistics Statistics { get; init; }
        
        [Required]
        public required WeatherExperience Experience { get; init; }

        [Required]
        public required ICollection<Location> Locations { get; init; }

        [Required]
        public required ICollection<WeatherEventAlert> Alerts { get; init; }
 
        public string? Description { get; init; }

        public DateTime? EndDate { get; init; }
    }
}