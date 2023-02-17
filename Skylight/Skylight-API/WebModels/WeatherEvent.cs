using System;
using System.Collections.Generic;

namespace Skylight.WebModels
{
    public class WeatherEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Weather Weather { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WeatherEventStatistics Statistics { get; set; } = null!;
        public WeatherExperience Experience { get; set; } = null!;

        public virtual ICollection<Location> Locations { get; set; } = new HashSet<Location>();
        public virtual ICollection<WeatherEventAlert> Alerts { get; set; } = new HashSet<WeatherEventAlert>();

        public WeatherEvent(
            string name, 
            string description, 
            DateTime startDate, 
            DateTime endDate
        )
        {
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}