namespace Skylight.Models
{
    /// <summary>
    /// Represents a relationships between a <see cref="WeatherExperience"/> and an actively participating <see cref="StormTracker"/>.
    /// </summary>
    public class WeatherExperienceParticipant : BaseIdentifiableModel
    {
        public virtual WeatherExperience Experience { get; set; } = null!;
        public virtual StormTracker Tracker { get; set; } = null!;
        public virtual WeatherEventObservationMethod ObservationMethod { get; set; } = null!;
    }
}