using FluentResults;
using MediatR;

namespace Skylight.Application.Interfaces.Application;

/// <summary>
/// Denotes an application query that returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface IQuery<TResponse> : IRequest<Result<TResponse>> where TResponse : IResponse { }
