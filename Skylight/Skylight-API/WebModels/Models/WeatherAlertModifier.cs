using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="WeatherAlertModifier"/>
    public record WeatherAlertModifier : BaseWebModel
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public required string Description { get; init; }

        [Required]
        public required float Bonus { get; init; }

        [Required]
        public required WeatherAlertModifierOperation Operation { get; init; }
    }
}