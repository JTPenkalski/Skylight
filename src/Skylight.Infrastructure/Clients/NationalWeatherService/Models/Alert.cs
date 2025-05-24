using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// A public alert message.
/// Unless otherwise noted, the fields in this object correspond to the National Weather Service CAP v1.2 specification,
/// which extends the OASIS Common Alerting Protocol (CAP) v1.2 specification and USA Integrated Public Alert and Warning System (IPAWS) Profile v1.0.
/// </summary>
/// <seealso href="http://docs.oasis-open.org/emergency/cap/v1.2/CAP-v1.2-os.html"/>
/// <seealso href="http://docs.oasis-open.org/emergency/cap/v1.2/ipaws-profile/v1.0/cs01/cap-v1.2-ipaws-profile-cs01.html"/>
public sealed record Alert(
	string Id,
	string AreaDescription,
	UgcZone[] Zones,
	DateTimeOffset Sent,
	DateTimeOffset Effective,
	DateTimeOffset? Onset,
	DateTimeOffset Expires,
	DateTimeOffset? Ends,
	AlertStatus Status,
	AlertMessageType MessageType,
	AlertSeverity Severity,
	AlertCategory Category,
	AlertUrgency Urgency,
	AlertCertainty Certainty,
	string Event,
	string SenderName,
	string? Headline,
	string Description,
	string? Instruction,
	AlertResponse Response,
	AwipsIdentifier AwipsId,
	EventMotionDescription? EventMotionDescription,
	string? WindThreat,
	string? MaxWindGust,
	string? HailThreat,
	string? MaxHailSize,
	string? ThunderstormDamageThreat,
	string? TornadoDetection,
	string? TornadoDamageThreat,
	string? FlashFloodDetection,
	string? FlashFloodDamageThreat,
	string? SnowSquallDetection,
	string? SnowSquallImpact,
	string? WaterspoutDetection,
	ValidTimeEventCode? ValidTimeEventCode,
	DateTimeOffset? EventEndingTime)
{
	public string TypeCode =>
		ValidTimeEventCode?.EventCode ?? AwipsId.ProductCategory;

	public string? ThunderstormThreat =>
		(HailThreat?.ToUpperInvariant(), WindThreat?.ToUpperInvariant()) switch
		{
			(AlertParameterValues.Observed, _) or (_, AlertParameterValues.Observed) => AlertParameterValues.Observed,
			(AlertParameterValues.RadarIndicated, _) or (_, AlertParameterValues.RadarIndicated) => AlertParameterValues.RadarIndicated,
			_ => null,
		};
}
