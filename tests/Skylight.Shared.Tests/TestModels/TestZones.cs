using Skylight.Domain.Alerts.Entities;

namespace Skylight.Shared.Tests.TestModels;

public static class TestZones
{
	/// <summary>
	/// Creates a basic test zone.
	/// </summary>
	public static Zone Default(Guid? id = null)
	{
		var zone = new Zone
		{
			Id = id ?? Guid.NewGuid(),
			Code = "TST",
			Name = "Test Zone",
		};

		return zone;
	}
}
