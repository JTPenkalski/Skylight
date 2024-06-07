using FluentResults;
using Microsoft.AspNetCore.Identity;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Domain.Entities;
using Skylight.Infrastructure.Identity.Utilities;

namespace Skylight.Infrastructure.Identity;

public class UserService(
	TimeProvider timeProvider,
	UserManager<User> userManager,
	RoleManager<Role> roleManager)
	: IUserService
{
	public async Task<Result> AddUserAsync(string firstName, string lastName, string email, string password, CancellationToken cancellationToken)
	{
		var user = new User
		{
			UserName = email,
			Email = email,
			StormTracker = new StormTracker
			{
				FirstName = firstName,
				LastName = lastName,
				StartDate = timeProvider.GetUtcNow(),
			}
		};

		IdentityResult result = await userManager.CreateAsync(user, password);

		return result.ToAppResult();
	}

	public async Task<Result> AddUserToRoleAsync(Guid userId, string role, CancellationToken cancellationToken)
	{
		User? user = await userManager.FindByIdAsync(userId.ToString());
		bool roleExists = await roleManager.RoleExistsAsync(role);

		if (user is not null && roleExists)
		{
			IdentityResult result = await userManager.AddToRoleAsync(user, role);

			return result.ToAppResult();
		}

		Result userResult = Result.FailIf(user is null, $"The user '{userId}' was not found.");
		Result roleResult = Result.FailIf(!roleExists, $"The role '{role}' does not exist.");

		return Result.Merge(userResult, roleResult);
	}

	public async Task<bool> IsUserInRoleAsync(Guid userId, string role, CancellationToken cancellationToken)
	{
		bool userHasRole = false;
		User? user = await userManager.FindByIdAsync(userId.ToString());

		if (user is not null)
		{
			bool roleExists = await roleManager.RoleExistsAsync(role);
			bool roleApplied = await userManager.IsInRoleAsync(user, role);

			userHasRole = roleExists && roleApplied;
		}

		return userHasRole;
	}

	public async Task<StormTracker?> GetStormTrackerByEmail(string email, CancellationToken cancellationToken)
	{
		User? user = await userManager.FindByEmailAsync(email);

		return user?.StormTracker;
	}
}
