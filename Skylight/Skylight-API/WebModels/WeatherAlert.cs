using System.Collections.Generic;

namespace Skylight.WebModels
{
    public class WeatherAlert
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public bool IsThirdParty { get; set; }
        
        public virtual ICollection<WeatherEventAlert> Events { get; set; } = new HashSet<WeatherEventAlert>();

        public WeatherAlert(string name, string description, float value, bool isThirdParty)
        {
            Name = name;
            Description = description;
            Value = value;
            IsThirdParty = isThirdParty;
        }
    }
}