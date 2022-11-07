namespace Skylight.Models
{
    public class WeatherExperienceParticipant
    {
        public int WeatherExperienceId { get; set; }
        public int StormTrackerId { get; set; }
        public WeatherEventObservationMethod ObservationMethod { get; set; } = null!;

        public WeatherExperienceParticipant(int weatherExperienceId, int stormTrackerId)
        {
            WeatherExperienceId = weatherExperienceId;
            StormTrackerId = stormTrackerId;
        }
    }
}