using Skylight.Forms.Guides;
using Skylight.Models;

namespace Skylight.Forms.Directors
{
    /// <summary>
    /// Determines how the controls on a <see cref="WeatherEvent"/> form should operate to ensure valid data.
    /// </summary>
    public interface IWeatherEventFormDirector : IFormDirector<WeatherEvent, WeatherEventFormGuide> { }
}