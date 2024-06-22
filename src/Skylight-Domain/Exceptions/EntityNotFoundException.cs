using Skylight.Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Skylight.Domain.Exceptions;

/// <summary>
/// Thrown when a <see cref="BaseEntity"/> is not found in the database, but should have been.
/// </summary>
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException() { }

    public EntityNotFoundException(string message) : base(message) { }

    public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    /// Throws an exception if <paramref name="entity"/> is null.
    /// </summary>
    /// <param name="entity">The entity to validate.</param>
    /// <param name="expectedId">The ID of <paramref name="entity"/> expected to be found.</param>
    /// <exception cref="EntityNotFoundException"/>
    public static void ThrowIfNull<T>([NotNull] T? entity, Guid? expectedId = null) where T : BaseEntity
    {
        if (entity is null)
        {
            throw new EntityNotFoundException($"{GetBaseExceptionMessage<T>(expectedId)} was not found!");
        }
    }

    /// <summary>
    /// Throws an exception if <paramref name="entity"/> is null or record-deleted.
    /// </summary>
    /// <param name="entity">The entity to validate.</param>
    /// <param name="expectedId">The ID of <paramref name="entity"/> expected to be found.</param>
    /// <exception cref="EntityNotFoundException"/>
    public static void ThrowIfNullOrDeleted<T>([NotNull] T? entity, Guid? expectedId = null) where T : BaseAuditableEntity
    {
        ThrowIfNull(entity, expectedId);

        if (entity.IsDeleted)
        {
            throw new EntityNotFoundException($"{GetBaseExceptionMessage<T>(expectedId)} is deleted!");
        }
    }

    private static string GetBaseExceptionMessage<T>(Guid? expectedId = null)
    {
        string expectedIdDisplay = expectedId.HasValue
                ? $"with ID = {expectedId.Value}"
                : string.Empty;

        return $"The entity '{typeof(T).Name}' {expectedIdDisplay}".Trim();
    }
}
