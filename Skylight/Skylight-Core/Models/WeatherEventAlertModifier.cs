namespace Skylight.Models
{
    /// <summary>
    /// Represents a specific instance of <see cref="WeatherAlertModifier"/> for a <see cref="WeatherEventAlert"/>.
    /// </summary>
    public class WeatherEventAlertModifier : BaseIdentifiableModel
    {
        public virtual WeatherEventAlert Alert { get; set; } = null!;
        public virtual WeatherAlertModifier Modifier { get; set; } = null!;
    }
}
