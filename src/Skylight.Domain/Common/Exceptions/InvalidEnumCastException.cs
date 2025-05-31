using Skylight.Domain.Common.Events;

namespace Skylight.Domain.Common.Exceptions;

/// <summary>
/// Thrown when a <see cref="DomainEvent"/> is not able to be dynamically constructed and published, but should have been.
/// </summary>
public class InvalidEnumCastException<T> : Exception
	where T : Enum
{
	private const string MessageFormat = "Cannot convert {0} into {1}!";

	public InvalidEnumCastException() { }

	public InvalidEnumCastException(string message) : base(message) { }

	public InvalidEnumCastException(string message, Exception inner) : base(message, inner) { }

	public InvalidEnumCastException(Enum other) : this(string.Format(MessageFormat, other, typeof(T).Name)) { }
}
