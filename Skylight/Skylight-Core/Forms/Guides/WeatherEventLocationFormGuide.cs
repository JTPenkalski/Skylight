using System;

namespace Skylight.Forms.Guides
{
    public class WeatherEventLocationFormGuide : FormGuide
    {
        public required FormControl<DateTimeOffset> StartTime { get; set; }
        public required FormControl<DateTimeOffset> EndTime { get; set; }
        public required LocationFormGuide Location { get; set; }
    }
}
