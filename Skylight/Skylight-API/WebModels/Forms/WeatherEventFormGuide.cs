using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventFormGuide"/>
    public class WeatherEventFormGuide : FormGuide
    {
        [Required]
        public required FormControlGuide Name { get; init; }
        
        [Required]
        public required FormControlGuide Experience { get; init; }
        
        [Required]
        public required FormControlGuide Weather { get; init; }
        
        [Required]
        public required FormControlGuide StartDate { get; init; }
        
        [Required]
        public required FormControlGuide EndDate { get; init; }
        
        [Required]
        public required FormControlGuide Description { get; init; }

        [Required]
        public required WeatherEventStatisticsFormGuide Statistics { get; init; }

        [Required]
        public required IEnumerable<WeatherEventLocationFormGuide> Locations { get; init; }
        
        [Required]
        public required IEnumerable<WeatherEventAlertFormGuide> Alerts { get; init; }
    }
}
