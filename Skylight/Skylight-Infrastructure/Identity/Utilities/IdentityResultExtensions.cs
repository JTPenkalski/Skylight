using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Skylight.Infrastructure.Identity.Utilities;

/// <summary>
/// Extension methods for <see cref="IdentityResult"/>.
/// </summary>
public static class IdentityResultExtensions
{
	/// <summary>
	/// Converts <paramref name="identityResult"/> to a <see cref="Result"/>.
	/// </summary>
	/// <returns>The new <see cref="Result"/> instance.</returns>
	public static Result ToAppResult(this IdentityResult identityResult) =>
		Result.Fail(identityResult.Errors.Select(x => $"[{x.Code}]: {x.Description}"));
}
