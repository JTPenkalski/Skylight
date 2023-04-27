using System;
using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents the summation of an entire weather occurence.
    /// It contains all of the data surrounding the large-scale event, which is usually comprised of multiple, discrete <see cref="WeatherEvent"/> instances.
    /// </summary>
    public class WeatherExperience : BaseIdentifiableModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual IEnumerable<WeatherExperienceParticipant> Participants { get; set; } = new List<WeatherExperienceParticipant>();
        public virtual IEnumerable<WeatherEvent> Events { get; set; } = new List<WeatherEvent>();

        /// <summary>
        /// Constructs a new <see cref="WeatherExperience"/> instance.
        /// </summary>
        /// <param name="name">The name of the experience.</param>
        /// <param name="description">A brief summary of the experience.</param>
        /// <param name="startTime">The earliest recorded time of the experience.</param>
        /// <param name="endTime">The final recorded time of the experience.</param>
        public WeatherExperience(string name, string description, DateTime startTime, DateTime endTime)
        {
            Name = name;
            Description = description;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}