using Skylight.Models;
using System;
using System.Collections.Generic;

namespace Skylight.Forms.Guides
{
    public class WeatherEventAlertFormGuide : FormGuide
    {
        public required FormControlGuide<WeatherAlert> Alert { get; set; }
        public required FormControlGuide<DateTimeOffset> IssuanceTime { get; set; }
        public required IEnumerable<FormControlGuide<WeatherAlertModifier>> Modifiers { get; set; }
    }
}
