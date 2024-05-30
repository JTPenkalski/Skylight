using FluentResults;
using MediatR;
using Skylight.Application.Attributes;
using Skylight.Domain.Exceptions;

namespace Skylight.Application.PipelineBehaviors;

/// <summary>
/// Catches any <see cref="EntityNotFoundException"/> and returns a failed <see cref="Result"/> to the sender.
/// </summary>
[ServiceBehavior]
public class EntityNotFoundExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
    where TResponse : ResultBase, new()
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (EntityNotFoundException ex)
        {
            var result = new TResponse();
            result.Reasons.Add(new Error(ex.Message));

            return result;
        }
    }
}
