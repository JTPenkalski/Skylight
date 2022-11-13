using Skylight.Attributes.Database;

namespace Skylight.Models
{
    public class WeatherExperienceParticipant
    {
        [CompositeKey] public WeatherExperience Experience { get; set; } = null!;
        [CompositeKey] public StormTracker Tracker { get; set; } = null!;
        public WeatherEventObservationMethod ObservationMethod { get; set; } = null!;
    }
}