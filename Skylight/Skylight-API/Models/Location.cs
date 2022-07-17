using System.Collections.Generic;

namespace Skylight.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<WeatherEvent> Events { get; set; } = null!;

        public Location(int id, string name, string description, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Description = description;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}