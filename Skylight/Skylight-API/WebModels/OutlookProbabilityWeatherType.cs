namespace Skylight.WebModels
{
    /// <summary>
    /// Represents a weather type that drives the assigned <see cref="RiskCategory"/> on a certain day with a certain probability.
    /// Traditionally, Day 1 and Day 2 outlooks are based on Tornado, Wind, and Hail risks separately, whereas Day 3 considers them all Combined.
    /// </summary>
    public enum OutlookProbabilityWeatherType
    {
        Combined,
        Hail,
        Thunderstorm,
        Tornado,
        Wind
    }
}
