namespace Skylight.Models
{
    public class WeatherEventObservationMethod
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public WeatherEventObservationMethod(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}