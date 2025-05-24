using Microsoft.AspNetCore.Identity;
using Skylight.Domain.Common.Results;

namespace Skylight.Infrastructure.Extensions;

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
		Result.Fail(identityResult.Errors.Select(x => new Error($"[{x.Code}]: {x.Description}")));
}
