namespace Skylight.Application.Common.Identity;

/// <summary>
/// Specialized interface for accessing the currently authenticated user, based on the current application context.
/// </summary>
public interface ICurrentUserService
{
	/// <summary>
	/// Gets the current application user.
	/// </summary>
	/// <returns>The unique username associated to the current user.</returns>
	string GetCurrentUser();
}
