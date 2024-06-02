using Asp.Versioning;
using FluentResults;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Skylight.Application.UseCases.Users.Commands;
using Skylight.Infrastructure.Identity;

namespace Skylight.Controllers;

/// <summary>
/// Web API Controller for manipulating <see cref="User"/> models.
/// </summary>
[ApiController]
[ApiVersion(SkylightApiVersion.VERSION)]
public class UserController(
	IMediator mediator,
	SignInManager<User> signInManager)
	: BaseController
{
	public sealed record SignInRequest(string Email, string Password);

	public sealed record SignInResponse(string TokenType, string AccessToken, long ExpiresIn, string RefreshToken);

	/// <summary>
	/// Checks if the current user is authenticated.
	/// </summary>
	/// <returns>True if the user is signed in, false otherwise.</returns>
	[HttpPost]
	[Route(nameof(IsSignedIn))]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public virtual ActionResult<bool> IsSignedIn(CancellationToken cancellationToken)
	{
		signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;

		bool isSignedIn = signInManager.IsSignedIn(HttpContext.User);

		return Ok(isSignedIn);
	}

	/// <summary>
	/// Registers a new user.
	/// </summary>
	[HttpPost]
	[AllowAnonymous]
	[Route(nameof(Register))]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public virtual async Task<ActionResult> Register(RegisterNewUserCommand request, CancellationToken cancellationToken)
	{
		Result result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Signs the current user in with the specified credentials.
	/// </summary>
	/// <seealso href="https://github.com/dotnet/aspnetcore/blob/main/src/Http/Authentication.Core/src/AuthenticationService.cs#L164"/>
	/// <seealso href="https://github.com/dotnet/aspnetcore/blob/main/src/Security/Authentication/BearerToken/src/BearerTokenHandler.cs#L64"/>
	[HttpPost]
	[AllowAnonymous]
	[Route(nameof(SignIn))]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public virtual async Task<ActionResult<SignInResponse>> SignIn(SignInRequest request, CancellationToken cancellationToken)
	{
		signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;

        Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(request.Email, request.Password, true, true);

		// The SignInManager writes to the Response directly
		return result.Succeeded
			? Empty
			: BadRequest();
	}

	/// <summary>
	/// Signs the current user out.
	/// </summary>
	[HttpPost]
	[Route(nameof(SignOut))]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public virtual async Task<ActionResult> SignOut(CancellationToken cancellationToken)
	{
		signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;

		await signInManager.SignOutAsync();

		return Ok();
	}

	/// <summary>
	/// Grants a user the Admin role.
	/// </summary>
	[HttpPost]
	[Route(nameof(GrantAdmin))]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public virtual async Task<ActionResult> GrantAdmin(GrantAdminCommand request, CancellationToken cancellationToken)
	{
		Result result = await mediator.Send(request, cancellationToken);
		
		return result.ToActionResult();
	}
}
