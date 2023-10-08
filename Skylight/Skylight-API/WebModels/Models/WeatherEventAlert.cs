using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="WeatherEventAlert"/>
    public record WeatherEventAlert : BaseWebModel
    {
        [Required]
        public required WeatherAlert Alert { get; init; }

        [Required]
        public required DateTime IssuanceTime { get; init; }

        [Required]
        public required IEnumerable<WeatherEventAlertModifier> Modifiers { get; init; }
    }
}
