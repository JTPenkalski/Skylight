using System.Collections.Generic;

namespace Skylight.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<WeatherEvent> Events { get; set; } = null!;

        public Location(int id, string city, string zipCode, string country, double latitude, double longitude)
        {
            Id = id;
            City = city;
            ZipCode = zipCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}