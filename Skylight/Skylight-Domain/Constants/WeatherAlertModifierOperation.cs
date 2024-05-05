using Skylight.Domain.Entities;

namespace Skylight.Domain.Constants;

/// <summary>
/// The operator to apply to the base value of a <see cref="WeatherAlert.Severity"/>
/// to obtain the total score for a <see cref="WeatherIncidentParticipant"/> who participated with the <see cref="WeatherAlert"/>,
/// based on <see cref="WeatherAlertModifier.Bonus"/>.
/// </summary>
public enum WeatherAlertModifierOperation
{
    Add,
    Multiply,
    Set
}
