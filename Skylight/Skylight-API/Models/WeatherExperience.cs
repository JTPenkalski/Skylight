using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherExperience
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ICollection<WeatherExperienceParticipant> Participants { get; set; } = new List<WeatherExperienceParticipant>();
        public ICollection<WeatherEvent> Events { get; set; } = new List<WeatherEvent>();
        public int DamageCost { get; set; }
        public int Fatalities { get; set; }

        public WeatherExperience(
            string name,
            string description,
            DateTime startTime,
            DateTime endTime,
            int damageCost,
            int fatalities
        )
        {
            Name = name;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
            DamageCost = damageCost;
            Fatalities = fatalities;
        }
    }
}