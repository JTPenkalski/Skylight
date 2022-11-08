namespace Skylight.Models
{
    public class WeatherAlert
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public bool IsThirdParty { get; set; }
        public WeatherAlertModifier Modifier { get; set; } = null!;

        public WeatherAlert(int id, string name, string description, float value, bool isThirdParty)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            IsThirdParty = isThirdParty;
        }
    }
}