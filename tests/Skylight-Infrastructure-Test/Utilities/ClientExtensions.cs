using Moq.Language.Flow;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Infrastructure.Services;
using System.Text.Json;

namespace Skylight.Tests.Infrastructure.Utilities;

internal static class ClientExtensions
{
	/// <summary>
	/// Uses a real implementation of the <see cref="IGeoJsonService"/>.
	/// </summary>
	internal static IReturnsResult<IGeoJsonService> SetUpRealService(this Mock<IGeoJsonService> mock) =>
		mock
			.Setup(x => x.GetGeoJsonProperties(It.IsAny<JsonElement>()))
			.Returns((JsonElement x) => new GeoJsonService().GetGeoJsonProperties(x));
}
