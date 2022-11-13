using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherEvent
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Weather Weather { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WeatherExperience Experience { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = new List<Location>();
        public ICollection<WeatherEventAlert> Alerts { get; set; } = new List<WeatherEventAlert>();
        public ICollection<WeatherEventStatistics> Statistics { get; set; } = new List<WeatherEventStatistics>();

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