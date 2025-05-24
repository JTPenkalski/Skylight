using Skylight.Domain.Alerts.Entities;

namespace Skylight.Shared.Tests.TestModels;

/// <summary>
/// Helper utility for <see cref="AlertParameter"/> testing.
/// </summary>
public readonly record struct AlertParameterKeyValue(AlertParameterKey Key, string Value);
