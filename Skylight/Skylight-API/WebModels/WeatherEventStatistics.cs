namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.WeatherEventStatistics"/>
    public record WeatherEventStatistics : BaseWebModel
    {
        public int? DamageCost { get; init; }
        
        public int? Fatalities { get; init; }
        
        public int? EFRating { get; init; }
        
        public int? PathDistance { get; init; }

        public int? FunnelWidth { get; init; }

        public int? SaffirSimpsonRating { get; init; }
        
        public int? LowestPressure { get; init; }

        public int? MaxWindSpeed { get; init; }
        
        public float? RichterMagnitude { get; init; }
        
        public int? MercalliIntensity { get; init; }
        
        public int? Aftershocks { get; init; }    

        public string? Fault { get; init; }
        
        public bool? RelatedTsunami { get; init; }
    }
}