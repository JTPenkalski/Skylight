namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherAlert"/>
    public record WeatherAlert : BaseWebModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
        public required float Value { get; init; }
        public required bool IsThirdParty { get; init; }
    }
}