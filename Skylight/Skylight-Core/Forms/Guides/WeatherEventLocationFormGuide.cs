﻿using System;

namespace Skylight.Forms.Guides
{
    public class WeatherEventLocationFormGuide : FormGuide
    {
        public required FormControlGuide<DateTimeOffset> StartTime { get; set; }
        public required FormControlGuide<DateTimeOffset> EndTime { get; set; }
        public required LocationFormGuide Location { get; set; }
    }
}
