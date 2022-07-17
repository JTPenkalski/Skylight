using System;

namespace Skylight.Models
{
    public class WeatherExperience
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Location Location { get; set; } = null!;
        public StormTracker Reporter { get; set; } = null!;
        public WeatherEventObservationMethod ObservationMethod { get; set; } = null!;
        public WeatherEvent Event { get; set; } = null!;
        public WeatherAlert Alert { get; set; } = null!;
        public WeatherEventSeverity Severity { get; set; } = null!;

        public WeatherExperience(int id, string name, string description, DateTime date)
        {
            Id = id;
            Name = name;
            Description = description;
            Date = date;
        }
    }
}