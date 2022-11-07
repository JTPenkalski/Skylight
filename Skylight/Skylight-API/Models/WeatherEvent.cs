using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public WeatherType WeatherType { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public WeatherExperience Experience { get; set; } = null!;
        public ICollection<Location> Locations { get; set; } = new List<Location>();
        public ICollection<WeatherAlert> Alerts { get; set; } = new List<WeatherAlert>();
        public ICollection<WeatherEventStatistics> Statistics { get; set; } = new List<WeatherEventStatistics>();

        public WeatherEvent(
            int id, 
            string name, 
            string description, 
            DateTime startDate, 
            DateTime endDate
        )
        {
            // TODO: Properly instantiate WeatherType and WeatherExperience
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}