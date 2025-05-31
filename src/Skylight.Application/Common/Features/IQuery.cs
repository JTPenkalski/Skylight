using Mediator;
using Skylight.Application.Common.Results;

namespace Skylight.Application.Common.Features;

/// <summary>
/// Denotes an application query that returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface IQuery<TResponse>
	: IRequest<Result<TResponse>>
	where TResponse : IResponse;
