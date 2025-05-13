using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Commands;
using Skylight.Application.Services;
using Skylight.Domain.Alerts.Entities;
using Skylight.Shared.Tests.TestModels;

namespace Skylight.Application.Tests.Features.Alerts.Commands;

public class AddCurrentAlertsTests
{
	private readonly Mock<ISkylightDbContext> dbContext = new();

	private readonly Mock<IWeatherAlertService> weatherAlertService = new();

	private AddCurrentAlertsHandler Handler => new(dbContext.Object, weatherAlertService.Object);

	#region AddNewAlerts

	[Fact]
	public void AddNewAlerts_ShouldNotAddAlert_WhenExisting()
	{
		// Arrange
		Guid sharedAlertId = Guid.NewGuid();
		List<Alert> currentAlerts = [TestAlerts.Default(id: sharedAlertId)];
		HashSet<Alert> existingAlerts = [TestAlerts.Default(id: sharedAlertId)];

		dbContext
			.SetupGet(x => x.Alerts)
			.Returns(Mock.Of<DbSet<Alert>>());

		// Act
		var result = Handler.AddNewAlerts(currentAlerts, existingAlerts);

		// Assert
		Assert.Empty(result);
	}

	[Fact]
	public void AddNewAlerts_ShouldAddAlert_WhenNew()
	{
		// Arrange
		List<Alert> currentAlerts = [TestAlerts.Default()];
		HashSet<Alert> existingAlerts = [];

		dbContext
			.SetupGet(x => x.Alerts)
			.Returns(Mock.Of<DbSet<Alert>>());

		// Act
		var result = Handler.AddNewAlerts(currentAlerts, existingAlerts);

		// Assert
		Assert.Single(result);
		Assert.Equal(currentAlerts[0].Type.Name, result[0].AlertName);
		Assert.Equal(currentAlerts[0].Sender.Name, result[0].SenderName);
	}

	[Fact]
	public void AddNewAlerts_ShouldAddAlert_WhenNewAndExisting()
	{
		// Arrange
		Guid sharedAlertId = Guid.NewGuid();
		List<Alert> currentAlerts = [TestAlerts.Default(id: sharedAlertId), TestAlerts.Default()];
		HashSet<Alert> existingAlerts = [TestAlerts.Default(id: sharedAlertId)];

		dbContext
			.SetupGet(x => x.Alerts)
			.Returns(Mock.Of<DbSet<Alert>>());

		// Act
		var result = Handler.AddNewAlerts(currentAlerts, existingAlerts);

		// Assert
		Assert.Single(result);
		Assert.Equal(currentAlerts[1].Type.Name, result[0].AlertName);
		Assert.Equal(currentAlerts[1].Sender.Name, result[0].SenderName);
	}

	#endregion
}
