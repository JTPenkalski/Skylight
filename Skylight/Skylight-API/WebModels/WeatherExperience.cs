using System;
using System.Collections.Generic;

namespace Skylight.WebModels
{
    public class WeatherExperience
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual ICollection<WeatherExperienceParticipant> Participants { get; set; } = new HashSet<WeatherExperienceParticipant>();
        public virtual ICollection<WeatherEvent> Events { get; set; } = new HashSet<WeatherEvent>();

        public WeatherExperience(
            string name,
            string description,
            DateTime startTime,
            DateTime endTime
        )
        {
            Name = name;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}