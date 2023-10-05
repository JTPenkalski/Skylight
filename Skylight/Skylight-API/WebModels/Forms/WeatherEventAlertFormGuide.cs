using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventAlertFormGuide"/>
    public class WeatherEventAlertFormGuide : FormGuide
    {
        [Required]
        public required FormControlGuide Alert { get; init; }
        
        [Required]
        public required FormControlGuide IssuanceTime { get; init; }
        
        [Required]
        public required IEnumerable<FormControlGuide> Modifiers { get; init; }
    }
}
