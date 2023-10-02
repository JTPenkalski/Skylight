using System;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="WeatherEventLocation"/>
    public record WeatherEventLocation : BaseWebModel
    {
        [Required]
        public required Location Location { get; init; }

        [Required]
        public required DateTime StartTime { get; init; }

        [Required]
        public required DateTime EndTime { get; init; }
    }
}
