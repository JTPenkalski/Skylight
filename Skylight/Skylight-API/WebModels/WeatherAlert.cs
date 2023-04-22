using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherAlert"/>
    public record WeatherAlert : BaseWebModel
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public required string Description { get; init; }

        [Required]
        public required float Value { get; init; }

        [Required]
        public required bool IsThirdParty { get; init; }

    }
}