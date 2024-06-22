using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Application.UseCases.Users.Constants;

namespace Skylight.Application.UseCases.Users;

public sealed record GrantAdminCommand(Guid UserId)
	: ICommand;

public class GrantAdminCommandHandler(IUserService userService)
	: ICommandHandler<GrantAdminCommand>
{
	public async Task<Result> Handle(GrantAdminCommand request, CancellationToken cancellationToken)
	{
		Result result = await userService.AddUserToRoleAsync(request.UserId, Roles.Admin, cancellationToken);

		return result;
	}
}
