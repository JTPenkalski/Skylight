﻿using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a specific instance of <see cref="WeatherAlert"/> for a <see cref="WeatherEvent"/>.
    /// </summary>
    public class WeatherEventAlert : BaseIdentifiableModel
    {
        public DateTime IssuanceTime { get; set; }

        public virtual WeatherEvent Event { get; set; } = null!;
        public virtual WeatherAlert Alert { get; set; } = null!;

        public virtual IEnumerable<WeatherAlertModifier> Modifiers { get; set; } = new List<WeatherAlertModifier>();
    }
}
