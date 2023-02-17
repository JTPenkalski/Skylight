namespace Skylight.Models
{
    /// <summary>
    /// Represents a relationships between a <see cref="WeatherExperience"/> and an actively participating <see cref="StormTracker"/>.
    /// </summary>
    public class WeatherExperienceParticipant : BaseIdentifiableModel
    {
        public WeatherExperience Experience { get; set; } = null!;
        public StormTracker Tracker { get; set; } = null!;
        public WeatherEventObservationMethod ObservationMethod { get; set; } = null!;
    }
}