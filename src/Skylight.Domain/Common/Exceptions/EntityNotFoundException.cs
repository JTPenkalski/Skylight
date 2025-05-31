using Skylight.Domain.Common.Entities;
using System.Diagnostics.CodeAnalysis;

namespace Skylight.Domain.Common.Exceptions;

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

	/// <inheritdoc cref="ThrowIfNull{T}(T?, Guid?)"/>
	/// <param name="expectedCode">The Code of <paramref name="entity"/> expected to be found.</param>
	public static void ThrowIfNull<T>([NotNull] T? entity, string expectedCode) where T : BaseEntity
	{
		if (entity is null)
		{
			throw new EntityNotFoundException($"{GetBaseExceptionMessage<T>(expectedCode)} was not found!");
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

		if (entity.DeletedOn.HasValue)
		{
			throw new EntityNotFoundException($"{GetBaseExceptionMessage<T>(expectedId)} is deleted!");
		}
	}

	/// <inheritdoc cref="ThrowIfNullOrDeleted{T}(T?, Guid?)"/>
	/// <param name="expectedCode">The Code of <paramref name="entity"/> expected to be found.</param>
	public static void ThrowIfNullOrDeleted<T>([NotNull] T? entity, string expectedCode) where T : BaseAuditableEntity
	{
		ThrowIfNull(entity, expectedCode);

		if (entity.DeletedOn.HasValue)
		{
			throw new EntityNotFoundException($"{GetBaseExceptionMessage<T>(expectedCode)} is deleted!");
		}
	}

	private static string GetBaseExceptionMessage<T>(Guid? expectedId = null)
	{
		string expectedIdDisplay = expectedId.HasValue
			? $"with ID = '{expectedId.Value}'"
			: string.Empty;

		return $"The '{typeof(T).Name}' entity {expectedIdDisplay}".Trim();
	}

	private static string GetBaseExceptionMessage<T>(string expectedCode) =>
		$"The '{typeof(T).Name}' entity with Code '{expectedCode}'".Trim();
}
