using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherAlert
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public bool IsThirdParty { get; set; }
        public ICollection<WeatherEventAlert> Events { get; set; } = new List<WeatherEventAlert>();

        public WeatherAlert(string name, string description, float value, bool isThirdParty)
        {
            Name = name;
            Description = description;
            Value = value;
            IsThirdParty = isThirdParty;
        }
    }
}