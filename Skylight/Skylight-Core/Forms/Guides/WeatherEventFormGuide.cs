using Skylight.Models;
using System;
using System.Collections.Generic;

namespace Skylight.Forms.Guides
{
    public class WeatherEventFormGuide : FormGuide
    {
        public required FormControl<string> Name { get; set; }
        public required FormControl<WeatherExperience> Experience { get; set; }
        public required FormControl<Weather> Weather { get; set; }
        public required FormControl<DateTimeOffset> StartDate { get; set; }
        public required FormControl<DateTimeOffset> EndDate { get; set; }
        public required FormControl<string> Description { get; set; }

        public required WeatherEventStatisticsFormGuide Statistics { get; set; }

        public required IEnumerable<WeatherEventLocationFormGuide> Locations { get; set; }
        public required IEnumerable<WeatherEventAlertFormGuide> Alerts { get; set; }
    }
}
