using Skylight.Models;
using System;
using System.Collections.Generic;

namespace Skylight.Forms.Guides
{
    public class WeatherEventAlertFormGuide : FormGuide
    {
        public required FormControl<WeatherAlert> Alert { get; set; }
        public required FormControl<DateTimeOffset> IssuanceTime { get; set; }
        public required IEnumerable<FormControl<WeatherAlertModifier>> Modifiers { get; set; }
    }
}
