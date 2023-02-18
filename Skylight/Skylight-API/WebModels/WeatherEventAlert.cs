using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEventAlert"/>
    public record WeatherEventAlert : BaseWebModel
    {
        public required WeatherEvent Event { get; init; }
        public required WeatherAlert Alert { get; init; }

        public virtual ICollection<WeatherAlertModifier> Modifier { get; init; } = new HashSet<WeatherAlertModifier>();
    }
}
