using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="WeatherEventAlertModifier"/>
    public record WeatherEventAlertModifier : BaseWebModel
    {
        [Required]
        public required WeatherAlertModifier Modifier { get; init; }
    }
}
