using Mediator;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Interfaces;

/// <summary>
/// Denotes an application query that returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface IQuery<TResponse>
	: IRequest<Result<TResponse>>
	where TResponse : IResponse;
