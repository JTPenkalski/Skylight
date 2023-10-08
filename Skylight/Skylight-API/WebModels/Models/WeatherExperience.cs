using System;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="WeatherExperience"/>
    public record WeatherExperience : BaseWebModel
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public required string Description { get; init; }

        [Required]
        public required DateTime StartTime { get; init; }

        public DateTime? EndTime { get; init; }
    }
}