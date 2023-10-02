namespace Skylight.Forms.Guides
{
    public class WeatherEventStatisticsFormGuide : FormGuide
    {
        public required FormControl<int> DamageCost { get; set; }
        public required FormControl<int> Fatalities { get; set; }
        public required FormControl<int> EFRating { get; set; }
        public required FormControl<int> PathDistance { get; set; }
        public required FormControl<int> FunnelWidth { get; set; }
        public required FormControl<int> SaffirSimpsonRating { get; set; }
        public required FormControl<int> LowestPressure { get; set; }
        public required FormControl<int> MaxWindSpeed { get; set; }
        public required FormControl<float> RichterMagnitude { get; set; }
        public required FormControl<int> MercalliIntensity { get; set; }
        public required FormControl<int> Aftershocks { get; set; }
        public required FormControl<string> Fault { get; set; }
        public required FormControl<bool> RelatedTsunami { get; set; }
    }
}
