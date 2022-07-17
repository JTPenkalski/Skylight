namespace Skylight.Models
{
    public class WeatherEventObservationMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public WeatherEventObservationMethod(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}