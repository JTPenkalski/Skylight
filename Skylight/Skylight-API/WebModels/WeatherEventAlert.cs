using System.Collections.Generic;

namespace Skylight.WebModels
{
    public class WeatherEventAlert
    {
        public WeatherEvent Event { get; set; } = null!;
        public WeatherAlert Alert { get; set; } = null!;

        public virtual ICollection<WeatherAlertModifier> Modifier { get; set; } = new HashSet<WeatherAlertModifier>();
    }
}
