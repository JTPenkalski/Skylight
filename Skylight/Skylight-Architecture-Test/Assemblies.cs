using System.Reflection;

namespace Skylight.Tests.Architecture;

/// <summary>
/// References to all Skylight assemblies.
/// </summary>
public static class Assemblies
{
    public static readonly Assembly Domain = typeof(Skylight.Domain.Entities.BaseEntity).Assembly;

    public static readonly Assembly Application = typeof(Skylight.Application.DependencyInjection).Assembly;

    public static readonly Assembly Infrastructure = typeof(Skylight.Infrastructure.DependencyInjection).Assembly;
}
