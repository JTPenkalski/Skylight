using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="WeatherExperienceParticipant"/>
    public record WeatherExperienceParticipant : BaseWebModel
    {
        [Required]
        public required WeatherExperience Experience { get; init; }

        [Required]
        public required StormTracker Tracker { get; init; }

        [Required]
        public required WeatherEventObservationMethod ObservationMethod { get; init; }
    }
}