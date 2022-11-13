using Skylight.Attributes.Database;
using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherEventAlert
    {
        [CompositeKey] public WeatherEvent Event { get; set; } = null!;
        [CompositeKey] public WeatherAlert Alert { get; set; } = null!;
        public ICollection<WeatherAlertModifier> Modifier { get; set; } = new List<WeatherAlertModifier>();
    }
}
