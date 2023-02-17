using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a specific instance of <see cref="WeatherAlert"/> for a <see cref="WeatherEvent"/>.
    /// </summary>
    public class WeatherEventAlert : BaseIdentifiableModel
    {
        public WeatherEvent Event { get; set; } = null!;
        public WeatherAlert Alert { get; set; } = null!;
        public DateTime IssuanceTime { get; set; }

        public virtual ICollection<WeatherAlertModifier> Modifier { get; set; } = new HashSet<WeatherAlertModifier>();
    }
}
