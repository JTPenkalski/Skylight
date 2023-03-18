using System;
using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEventAlert"/>
    public record WeatherEventAlert : BaseWebModel
    {
        public required WeatherAlert Alert { get; init; }
        public required DateTime IssuanceTime { get; init; }

        public ICollection<WeatherAlertModifier> Modifiers { get; init; } = new HashSet<WeatherAlertModifier>();
    }
}
