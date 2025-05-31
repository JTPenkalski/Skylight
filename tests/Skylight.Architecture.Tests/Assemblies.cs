using System.Reflection;

namespace Skylight.Architecture.Tests;

/// <summary>
/// References to all Skylight assemblies.
/// </summary>
public static class Assemblies
{
	public static readonly Assembly Domain = typeof(Skylight.Domain.Common.Entities.BaseEntity).Assembly;
	public static readonly Assembly Application = typeof(Skylight.Application.Bootstrap).Assembly;
	public static readonly Assembly Infrastructure = typeof(Skylight.Infrastructure.Bootstrap).Assembly;
	public static readonly Assembly API = typeof(Skylight.API.Bootstrap).Assembly;
}
