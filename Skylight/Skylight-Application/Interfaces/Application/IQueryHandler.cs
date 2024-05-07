using FluentResults;
using MediatR;

namespace Skylight.Application.Interfaces.Application;

/// <summary>
/// Denotes a service that handles a <typeparamref name="TQuery"/> query and returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse> { }
