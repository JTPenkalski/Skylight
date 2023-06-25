using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEventAlertModifier"/>
    public record WeatherEventAlertModifier : BaseWebModel
    {
        [Required]
        public required WeatherAlertModifier Modifier { get; init; }
    }
}
