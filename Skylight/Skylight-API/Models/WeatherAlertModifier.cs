using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherAlertModifier
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Bonus { get; set; }
        public WeatherAlertModifierOperation Operation { get; set; }
        public ICollection<WeatherEventAlert> Alerts { get; set; } = new List<WeatherEventAlert>();

        public WeatherAlertModifier(string name, string description, float bonus, WeatherAlertModifierOperation operation)
        {
            Name = name;
            Description = description;
            Bonus = bonus;
            Operation = operation;
        }
    }
}