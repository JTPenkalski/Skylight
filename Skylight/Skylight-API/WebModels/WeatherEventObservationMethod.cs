namespace Skylight.WebModels
{
    public class WeatherEventObservationMethod
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public WeatherEventObservationMethod(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}