namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEventObservationMethod"/>
    public record WeatherEventObservationMethod : BaseWebModel
    {
        public required string Name { get; init; }
        public required string Description { get; init; }
    }
}