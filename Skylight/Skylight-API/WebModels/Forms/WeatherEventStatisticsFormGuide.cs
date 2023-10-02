using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventStatisticsFormGuide"/>
    public class WeatherEventStatisticsFormGuide : FormGuide
    {
        [Required]
        public required FormControl<int> DamageCost { get; init; }
        
        [Required]
        public required FormControl<int> Fatalities { get; init; }
        
        [Required]
        public required FormControl<int> EFRating { get; init; }
        
        [Required]
        public required FormControl<int> PathDistance { get; init; }
        
        [Required]
        public required FormControl<int> FunnelWidth { get; init; }
        
        [Required]
        public required FormControl<int> SaffirSimpsonRating { get; init; }
        
        [Required]
        public required FormControl<int> LowestPressure { get; init; }
        
        [Required]
        public required FormControl<int> MaxWindSpeed { get; init; }
        
        [Required]
        public required FormControl<float> RichterMagnitude { get; init; }
        
        [Required]
        public required FormControl<int> MercalliIntensity { get; init; }
        
        [Required]
        public required FormControl<int> Aftershocks { get; init; }
        
        [Required]
        public required FormControl<string> Fault { get; init; }
        
        [Required]
        public required FormControl<bool> RelatedTsunami { get; init; }
    }
}
