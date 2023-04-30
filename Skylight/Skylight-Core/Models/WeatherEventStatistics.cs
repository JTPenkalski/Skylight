namespace Skylight.Models
{
    /// <summary>
    /// Represents a comprehensive set of statistics about a variety of weather types.
    /// It is intended that only the relevant statistics are used for a particular <see cref="WeatherEvent"/>.
    /// </summary>
    public class WeatherEventStatistics : BaseIdentifiableModel
    {
        public int? DamageCost { get; set; }
        public int? Fatalities { get; set; }
        public int? EFRating { get; set; }
        public int? PathDistance { get; set; }
        public int? FunnelWidth { get; set; }
        public int? SaffirSimpsonRating { get; set; }
        public int? LowestPressure { get; set; }
        public int? MaxWindSpeed { get; set; }
        public float? RichterMagnitude { get; set; }
        public int? MercalliIntensity { get; set; }
        public int? Aftershocks { get; set; }
        public string? Fault { get; set; }
        public bool? RelatedTsunami { get; set; }
    }
}