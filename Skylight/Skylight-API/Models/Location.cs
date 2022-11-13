using System.Collections.Generic;

namespace Skylight.Models
{
    public class Location
    {
        public int Id { get; private set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<WeatherEvent> Events { get; set; } = new List<WeatherEvent>();

        public Location(string city, string zipCode, string country, double latitude, double longitude)
        {
            City = city;
            ZipCode = zipCode;
            Country = country;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}