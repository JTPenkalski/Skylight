using Skylight.Domain.Events;
using System.Diagnostics.CodeAnalysis;

namespace Skylight.Domain.Exceptions;

/// <summary>
/// Thrown when a <see cref="DomainEvent"/> is not able to be dynamically constructed and published, but should have been.
/// </summary>
public class InvalidDomainEventException : Exception
{
	public InvalidDomainEventException() { }

	public InvalidDomainEventException(string message) : base(message) { }

	public InvalidDomainEventException(string message, Exception inner) : base(message, inner) { }

	/// <summary>
	/// Throws an exception if a <paramref name="domainEvent"/> is null because it failed to be deserialized properly.
	/// </summary>
	/// <param name="domainEvent">The domain event to validate.</param>
	/// <param name="expectedType">The type expected to be created.</param>
	/// <exception cref="InvalidDomainEventException"/>
	public static void ThrowIfNull([NotNull] DomainEvent? domainEvent, string expectedType)
	{
		if (domainEvent is null)
		{
			throw new InvalidDomainEventException($"The {nameof(DomainEvent)} '{expectedType}' could not be created!");
		}
	}
}
