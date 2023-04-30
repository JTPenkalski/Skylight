using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a type of notification used to inform people about impending weather with varying degrees of severity.
    /// </summary>
    public class WeatherAlert : BaseIdentifiableModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public bool IsThirdParty { get; set; }

        public virtual ICollection<WeatherEventAlert> Events { get; set; } = new List<WeatherEventAlert>();

        /// <summary>
        /// Constructs a new <see cref="WeatherAlert"/> instance.
        /// </summary>
        /// <param name="name">The name of the alert type.</param>
        /// <param name="description">A brief description about what the alert type is.</param>
        /// <param name="value">How many points tracking this alert type is worth, contributing to a Storm Tracker's total score.</param>
        /// <param name="isThirdParty">Whether or not this alert type is used by the SPC or a custom type used by some independent weather service.</param>
        public WeatherAlert(string name, string description, float value, bool isThirdParty)
        {
            Name = name;
            Description = description;
            Value = value;
            IsThirdParty = isThirdParty;
        }
    }
}