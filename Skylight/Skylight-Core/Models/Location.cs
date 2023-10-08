using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents the specific location a weather event happened in.
    /// </summary>
    public class Location : BaseIdentifiableModel
    {
        public string City { get; set; }
        public string Country { get; set; }

        public virtual ICollection<WeatherEventLocation> Events { get; set; } = new List<WeatherEventLocation>();

        /// <summary>
        /// Constructs a new <see cref="Location"/> instance.
        /// </summary>
        /// <param name="city">The name of the city.</param>
        /// <param name="country">The country the city is located in.</param>
        public Location(string city, string country = "United States")
        {
            City = city;
            Country = country;
        }
    }
}