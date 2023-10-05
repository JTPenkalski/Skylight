using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventStatisticsFormGuide"/>
    public class WeatherEventStatisticsFormGuide : FormGuide
    {
        [Required]
        public required FormControlGuide DamageCost { get; init; }
        
        [Required]
        public required FormControlGuide Fatalities { get; init; }
        
        [Required]
        public required FormControlGuide EFRating { get; init; }
        
        [Required]
        public required FormControlGuide PathDistance { get; init; }
        
        [Required]
        public required FormControlGuide FunnelWidth { get; init; }
        
        [Required]
        public required FormControlGuide SaffirSimpsonRating { get; init; }
        
        [Required]
        public required FormControlGuide LowestPressure { get; init; }
        
        [Required]
        public required FormControlGuide MaxWindSpeed { get; init; }
        
        [Required]
        public required FormControlGuide RichterMagnitude { get; init; }
        
        [Required]
        public required FormControlGuide MercalliIntensity { get; init; }
        
        [Required]
        public required FormControlGuide Aftershocks { get; init; }
        
        [Required]
        public required FormControlGuide Fault { get; init; }
        
        [Required]
        public required FormControlGuide RelatedTsunami { get; init; }
    }
}
