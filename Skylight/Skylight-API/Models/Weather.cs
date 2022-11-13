using System.Collections.Generic;

namespace Skylight.Models
{
    public class Weather
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<WeatherEvent> Events { get; set; } = new List<WeatherEvent>();

        public Weather(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}