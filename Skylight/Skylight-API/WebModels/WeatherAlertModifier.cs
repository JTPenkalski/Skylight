namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherAlertModifier"/>
    public record WeatherAlertModifier : BaseWebModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required float Bonus { get; init; }
        public required WeatherAlertModifierOperation Operation { get; init; }
    }
}