namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEventStatistics"/>
    public record WeatherEventStatistics : BaseWebModel
    {
        public required int? DamageCost { get; init; }
        public required int? Fatalities { get; init; }
        public required string? EFRating { get; init; }
        public required int? PathDistance { get; init; }
        public required int? FunnelWidth { get; init; }
        public required string? SaffirSimpsonRating { get; init; }
        public required int? LowestPressure { get; init; }
        public required int? MaxWindSpeed { get; init; }
        public required float? RichterMagnitude { get; init; }
        public required int? MercalliIntensity { get; init; }
        public required int? Aftershocks { get; init; }
        public required string? Fault { get; init; }
        public required bool? RelatedTsunami { get; init; }
    }
}