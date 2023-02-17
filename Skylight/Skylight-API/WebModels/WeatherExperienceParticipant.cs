namespace Skylight.WebModels
{
    public class WeatherExperienceParticipant
    {
        public WeatherExperience Experience { get; set; } = null!;
        public StormTracker Tracker { get; set; } = null!;
        public WeatherEventObservationMethod ObservationMethod { get; set; } = null!;
    }
}