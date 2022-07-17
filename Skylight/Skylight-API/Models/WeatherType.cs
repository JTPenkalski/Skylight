using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<WeatherEvent> Events { get; set; } = null!;

        public WeatherType(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}