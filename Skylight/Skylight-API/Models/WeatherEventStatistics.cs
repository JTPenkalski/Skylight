namespace Skylight.Models
{
    public class WeatherEventStatistics
    {
        public int Id { get; set; }
        public string? EFRating { get; set; }
        public int? PathDistance { get; set; }
        public int? FunnelWidth { get; set; }
        public string? SaffirSimpsonRating { get; set; }
        public int? LowestPressure { get; set; }
        public int? MaxWindSpeed { get; set; }
        public float? RichterMagnitude { get; set; }
        public int? MercalliIntensity { get; set; }
        public int? Aftershocks { get; set; }
        public string? Fault { get; set; }
        public bool? RelatedTsunami { get; set; }
    }
}