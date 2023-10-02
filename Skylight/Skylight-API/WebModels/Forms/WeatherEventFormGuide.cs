using Skylight.WebModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventFormGuide"/>
    public class WeatherEventFormGuide : FormGuide
    {
        [Required]
        public required FormControl<string> Name { get; init; }
        
        [Required]
        public required FormControl<WeatherExperience> Experience { get; init; }
        
        [Required]
        public required FormControl<Weather> Weather { get; init; }
        
        [Required]
        public required FormControl<DateTimeOffset> StartDate { get; init; }
        
        [Required]
        public required FormControl<DateTimeOffset> EndDate { get; init; }
        
        [Required]
        public required FormControl<string> Description { get; init; }

        [Required]
        public required WeatherEventStatisticsFormGuide Statistics { get; init; }

        [Required]
        public required IEnumerable<WeatherEventLocationFormGuide> Locations { get; init; }
        
        [Required]
        public required IEnumerable<WeatherEventAlertFormGuide> Alerts { get; init; }
    }
}
