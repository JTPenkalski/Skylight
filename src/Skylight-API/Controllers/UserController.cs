﻿using Asp.Versioning;
using FluentResults;
using FluentResults.Extensions.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Skylight.Application.UseCases.StormTrackers;
using Skylight.Application.UseCases.Users;
using Skylight.Infrastructure.Identity;
using IdentitySignInResult = Microsoft.AspNetCore.Identity.SignInResult;

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

	public sealed record GetCurrentUserResponse(Guid StormTrackerId, string Email, string FirstName, string LastName);

	/// <summary>
	/// Checks if the current user is authenticated.
	/// </summary>
	[HttpPost]
	[AllowAnonymous]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public ActionResult<bool> IsSignedIn()
	{
		// Apparently, even though we're using Bearer, HttpContext.User has Identity.Application ???
		// signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;

		bool isSignedIn = signInManager.IsSignedIn(HttpContext.User);

		return Ok(isSignedIn);
	}

	/// <summary>
	/// Signs the current user in with the specified credentials.
	/// </summary>
	/// <seealso href="https://github.com/dotnet/aspnetcore/blob/main/src/Http/Authentication.Core/src/AuthenticationService.cs#L164"/>
	/// <seealso href="https://github.com/dotnet/aspnetcore/blob/main/src/Security/Authentication/BearerToken/src/BearerTokenHandler.cs#L64"/>
	[HttpPost]
	[AllowAnonymous]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<SignInResponse>> SignIn(SignInRequest request)
	{
		signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;

		IdentitySignInResult result = await signInManager.PasswordSignInAsync(request.Email, request.Password, true, true);

		// The SignInManager writes to the Response directly
		return result.Succeeded
			? Empty
			: BadRequest();
	}

	/// <summary>
	/// Signs the current user out.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public new async Task<ActionResult> SignOut()
	{
		signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;

		await signInManager.SignOutAsync();

		return Ok();
	}

	/// <summary>
	/// Registers a new user.
	/// </summary>
	[HttpPost]
	[AllowAnonymous]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> Register(RegisterNewUserCommand request, CancellationToken cancellationToken)
	{
		Result result = await mediator.Send(request, cancellationToken);

		return result.ToActionResult();
	}

	/// <summary>
	/// Grants a user the Admin role.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult> GrantAdmin(GrantAdminCommand request, CancellationToken cancellationToken)
	{
		Result result = await mediator.Send(request, cancellationToken);
		
		return result.ToActionResult();
	}

	/// <summary>
	/// Get the currently authenticated user.
	/// </summary>
	[HttpPost]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	public async Task<ActionResult<GetCurrentUserResponse>> GetCurrentUser(CancellationToken cancellationToken)
	{
		string? currentUserEmail = User.Identity?.Name;

		if (!string.IsNullOrWhiteSpace(currentUserEmail))
		{
			var request = new GetStormTrackerByEmailQuery(currentUserEmail);

			Result<GetStormTrackerByEmailResponse> result = await mediator.Send(request, cancellationToken);

			return result
				.Map(x =>
					new GetCurrentUserResponse(
						x.StormTrackerId,
						currentUserEmail,
						x.FirstName,
						x.LastName))
				.ToActionResult();
		}

		return BadRequest();
	}
}
