using System;
using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherExperience"/>
    public record WeatherExperience : BaseWebModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required DateTime StartTime { get; init; }
        public required DateTime EndTime { get; init; }

        public virtual ICollection<WeatherExperienceParticipant> Participants { get; init; } = new HashSet<WeatherExperienceParticipant>();
        public virtual ICollection<WeatherEvent> Events { get; init; } = new HashSet<WeatherEvent>();
    }
}