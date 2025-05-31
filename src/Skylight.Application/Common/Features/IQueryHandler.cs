using Mediator;
using Skylight.Application.Common.Results;

namespace Skylight.Application.Common.Features;

/// <summary>
/// Denotes a service that handles a <typeparamref name="TQuery"/> query and returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface IQueryHandler<in TQuery, TResponse>
	: IRequestHandler<TQuery, Result<TResponse>>
	where TQuery : IQuery<TResponse>
	where TResponse : IResponse;
