using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a modification to the base value of a <see cref="WeatherAlert"/>.
    /// Typically used in special cases to increase the value for rare occurences.
    /// </summary>
    public class WeatherAlertModifier : BaseIdentifiableModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Bonus { get; set; }
        public WeatherAlertModifierOperation Operation { get; set; }

        public virtual ICollection<WeatherEventAlert> Alerts { get; set; } = new List<WeatherEventAlert>();

        /// <summary>
        /// Constructs a new <see cref="WeatherAlertModifier"/> instance.
        /// </summary>
        /// <param name="name">The name of the alert modifier type.</param>
        /// <param name="description">A brief description about what the alert modifier type is.</param>
        /// <param name="bonus">The factor to modify the value by.</param>
        /// <param name="operation">The mathematical operation used to apply the bonus factor.</param>
        public WeatherAlertModifier(string name, string description, float bonus, WeatherAlertModifierOperation operation)
        {
            Name = name;
            Description = description;
            Bonus = bonus;
            Operation = operation;
        }
    }
}