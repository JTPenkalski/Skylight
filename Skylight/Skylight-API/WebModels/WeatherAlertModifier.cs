using System.Collections.Generic;

namespace Skylight.WebModels
{
    public class WeatherAlertModifier
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Bonus { get; set; }
        public WeatherAlertModifierOperation Operation { get; set; }

        public virtual ICollection<WeatherEventAlert> Alerts { get; set; } = new HashSet<WeatherEventAlert>();

        public WeatherAlertModifier(string name, string description, float bonus, WeatherAlertModifierOperation operation)
        {
            Name = name;
            Description = description;
            Bonus = bonus;
            Operation = operation;
        }
    }
}