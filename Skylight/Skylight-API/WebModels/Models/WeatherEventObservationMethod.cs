using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="WeatherEventObservationMethod"/>
    public record WeatherEventObservationMethod : BaseWebModel
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public required string Description { get; init; }
    }
}