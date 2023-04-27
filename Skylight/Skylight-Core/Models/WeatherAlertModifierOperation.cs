namespace Skylight.Models
{
    /// <summary>
    /// The operator to apply to a <see cref="WeatherAlertModifier"/> to the total score for a <see cref="StormTracker"/>,
    /// relative to the base value of <see cref="WeatherAlert.Value"/>.
    /// </summary>
    public enum WeatherAlertModifierOperation
    {
        Add,
        Multiply,
        Set
    }
}
