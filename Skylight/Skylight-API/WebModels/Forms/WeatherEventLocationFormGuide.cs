using Skylight.WebModels.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventLocationFormGuide"/>
    public class WeatherEventLocationFormGuide : FormGuide
    {
        [Required]
        public required FormControl<DateTimeOffset> StartTime { get; init; }
        
        [Required]
        public required FormControl<DateTimeOffset> EndTime { get; init; }
        
        [Required]
        public required LocationFormGuide Location { get; init; }
    }
}
