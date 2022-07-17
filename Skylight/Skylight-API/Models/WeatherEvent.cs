using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Uri SpcOutlook { get; set; }
        public ICollection<Location> Locations { get; set; } = null!;
        public ICollection<WeatherType> WeatherTypes { get; set; } = null!;
        public RiskCategory HighestRiskCategory { get; set; } = null!;

        public WeatherEvent(int id, string name, string description, DateTime startDate, DateTime endDate, Uri spcOutlook)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            SpcOutlook = spcOutlook;
        }
    }
}