namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherExperienceParticipant"/>
    public record WeatherExperienceParticipant : BaseWebModel
    {
        public required WeatherExperience Experience { get; init; }
        public required StormTracker Tracker { get; init; }
        public required WeatherEventObservationMethod ObservationMethod { get; init; }
    }
}