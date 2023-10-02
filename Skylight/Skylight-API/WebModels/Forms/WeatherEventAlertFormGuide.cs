using Skylight.WebModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.WeatherEventAlertFormGuide"/>
    public class WeatherEventAlertFormGuide : FormGuide
    {
        [Required]
        public required FormControl<WeatherAlert> Alert { get; init; }
        
        [Required]
        public required FormControl<DateTimeOffset> IssuanceTime { get; init; }
        
        [Required]
        public required IEnumerable<FormControl<WeatherAlertModifier>> Modifiers { get; init; }
    }
}
