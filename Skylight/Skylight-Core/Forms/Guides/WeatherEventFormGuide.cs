using Skylight.Models;
using System;
using System.Collections.Generic;

namespace Skylight.Forms.Guides
{
    public class WeatherEventFormGuide : FormGuide
    {
        public required FormControlGuide<string> Name { get; set; }
        public required FormControlGuide<WeatherExperience> Experience { get; set; }
        public required FormControlGuide<Weather> Weather { get; set; }
        public required FormControlGuide<DateTimeOffset> StartDate { get; set; }
        public required FormControlGuide<DateTimeOffset?> EndDate { get; set; }
        public required FormControlGuide<string?> Description { get; set; }

        public required WeatherEventStatisticsFormGuide Statistics { get; set; }

        public required IEnumerable<WeatherEventLocationFormGuide> Locations { get; set; }
        public required IEnumerable<WeatherEventAlertFormGuide> Alerts { get; set; }
    }
}
