using FluentResults;
using FluentValidation;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Infrastructure;

namespace Skylight.Application.UseCases.Users.Commands;

public sealed record RegisterNewUserCommand(
	string FirstName,
	string LastName,
	string Email,
	string Password)
	: ICommand;

public class RegisterNewUserCommandValidator : AbstractValidator<RegisterNewUserCommand>
{
	public RegisterNewUserCommandValidator()
	{
		RuleFor(x => x.FirstName)
			.NotEmpty();

		RuleFor(x => x.LastName)
			.NotEmpty();

		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress();
	}
}

public class RegisterNewUserCommandHandler(IUserService userService)
	: ICommandHandler<RegisterNewUserCommand>
{
	public async Task<Result> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
	{
		// TODO: Add request validator...

		Result result = await userService.AddUserAsync(
			request.FirstName,
			request.LastName,
			request.Email,
			request.Password,
			cancellationToken);

		return result;
	}
}
