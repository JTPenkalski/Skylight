namespace Skylight.Forms.Guides
{
    public class WeatherEventStatisticsFormGuide : FormGuide
    {
        public required FormControlGuide<int?> DamageCost { get; set; }
        public required FormControlGuide<int?> Fatalities { get; set; }
        public required FormControlGuide<int?> EFRating { get; set; }
        public required FormControlGuide<int?> PathDistance { get; set; }
        public required FormControlGuide<int?> FunnelWidth { get; set; }
        public required FormControlGuide<int?> SaffirSimpsonRating { get; set; }
        public required FormControlGuide<int?> LowestPressure { get; set; }
        public required FormControlGuide<int?> MaxWindSpeed { get; set; }
        public required FormControlGuide<float?> RichterMagnitude { get; set; }
        public required FormControlGuide<int?> MercalliIntensity { get; set; }
        public required FormControlGuide<int?> Aftershocks { get; set; }
        public required FormControlGuide<string?> Fault { get; set; }
        public required FormControlGuide<bool?> RelatedTsunami { get; set; }
    }
}
