namespace Skylight.Application.Common.Identity;

/// <summary>
/// Specialized interface for accessing the currently authenticated user, based on the current application context.
/// </summary>
public interface ICurrentUserService
{
	/// <summary>
	/// Gets the current application user ID.
	/// </summary>
	/// <returns>The unique ID associated to the current user.</returns>
	Guid GetCurrentUserId();
}
