using Microsoft.AspNetCore.Mvc;
using Skylight.Domain.Common.Results;

namespace Skylight.API.Extensions;

public static class ResultExtensions
{
	/// <summary>
	/// Converts a <see cref="Result{T}"/> into an <see cref="ActionResult{TValue}"/> compatible with HTTP endpoints.
	/// </summary>
	/// <returns>A new <see cref="ActionResult{TValue}"/> instance.</returns>
	public static ActionResult<T> ToActionResult<T>(this Result<T> result)
	{
		return result.IsSuccess
			? new OkObjectResult(result.Value)
			: new BadRequestObjectResult(result.Errors);
	}
}
