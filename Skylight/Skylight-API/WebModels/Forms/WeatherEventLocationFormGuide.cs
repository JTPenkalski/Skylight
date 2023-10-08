using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventLocationFormGuide"/>
    public class WeatherEventLocationFormGuide : FormGuide
    {
        [Required]
        public required FormControlGuide StartTime { get; init; }
        
        [Required]
        public required FormControlGuide EndTime { get; init; }
        
        [Required]
        public required LocationFormGuide Location { get; init; }
    }
}
