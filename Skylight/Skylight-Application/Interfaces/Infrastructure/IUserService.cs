using FluentResults;

namespace Skylight.Application.Interfaces.Infrastructure;

/// <summary>
/// Manages users within the <see cref="Skylight"/> application.
/// </summary>
public interface IUserService
{
	/// <summary>
	/// Registers a new user.
	/// </summary>
	/// <param name="firstName">The user's first name.</param>
	/// <param name="lastName">The user's last name.</param>
	/// <param name="email">The username/email of the user.</param>
	/// <param name="password">The password of the user.</param>
	/// <returns>The result of the operation.</returns>
	Task<Result> AddUserAsync(string firstName, string lastName, string email, string password, CancellationToken cancellationToken);

	/// <summary>
	/// Grants a user the specified role.
	/// </summary>
	/// <param name="userId">The ID of the user to modify.</param>
	/// <param name="role">The name of the role to grant.</param>
	/// <returns>The result of the operation.</returns>
	Task<Result> AddUserToRoleAsync(Guid userId, string role, CancellationToken cancellationToken);

	/// <summary>
	/// Verifies if a user is already granted the specified role.
	/// </summary>
	/// <param name="userId">The ID of the user to modify.</param>
	/// <param name="role">The name of the role to grant.</param>
	/// <returns>True if the user is already granted the role, false otherwise.</returns>
	Task<bool> IsUserInRoleAsync(Guid userId, string role, CancellationToken cancellationToken);
}
