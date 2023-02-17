using System.Collections.Generic;

namespace Skylight.WebModels
{
    public class Weather
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WeatherEvent> Events { get; set; } = new HashSet<WeatherEvent>();

        public Weather(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}