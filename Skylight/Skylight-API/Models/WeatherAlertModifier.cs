using System.Collections.Generic;

namespace Skylight.Models
{
    public class WeatherAlertModifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Bonus { get; set; }
        public WeatherAlertModifierOperation Operation { get; set; }
        public ICollection<WeatherAlert> Alerts { get; set; } = null!;

        public WeatherAlertModifier(int id, string name, string description, float bonus, WeatherAlertModifierOperation operation)
        {
            Id = id;
            Name = name;
            Description = description;
            Bonus = bonus;
            Operation = operation;
        }
    }
}