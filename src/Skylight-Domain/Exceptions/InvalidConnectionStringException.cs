using System.Diagnostics.CodeAnalysis;

namespace Skylight.Domain.Exceptions;

/// <summary>
/// Thrown when an invalid connection string is used in an attempt to contact a database.
/// </summary>
public class InvalidConnectionStringException : Exception
{
    public InvalidConnectionStringException() { }

    public InvalidConnectionStringException(string message) : base(message) { }

    public InvalidConnectionStringException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Throws an exception if <paramref name="connectionString"/> is null, empty, or consists only of white-space characters.
    /// </summary>
    /// <param name="connectionString">The connection string to validate.</param>
    /// <exception cref="InvalidConnectionStringException" />
    public static void ThrowIfNullOrWhiteSpace([NotNull] string? connectionString, string connectionName)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidConnectionStringException($"The connection string '{connectionName}' is null or whitespace!");
        }
    }
}
