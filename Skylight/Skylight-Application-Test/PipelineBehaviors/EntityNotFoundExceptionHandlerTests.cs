using FluentResults;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.PipelineBehaviors;
using Skylight.Domain.Entities;
using Skylight.Domain.Exceptions;

namespace Skylight.Tests.Application.PipelineBehaviors;

public class EntityNotFoundExceptionHandlerTests
{
    public sealed record TestCommand(Action Action) : ICommand;

    public class TestCommandHandler : ICommandHandler<TestCommand>
    {
        public Task<Result> Handle(TestCommand request, CancellationToken cancellationToken)
        {
            request.Action();

            return Task.FromResult(Result.Ok());
        }
    }

    [Fact]
    public async Task Handle_Should_Set_Handled()
    {
        // Arrange
        var command = new TestCommand(() => { });
        var exception = new EntityNotFoundException("MESSAGE");
        var state = new RequestExceptionHandlerState<Result>();

        var handler = new EntityNotFoundExceptionHandler();

        // Act
        await handler.Handle(command, exception, state, CancellationToken.None);

        // Assert
        Assert.True(state.Handled);
        Assert.True(state.Response!.IsFailed);
        Assert.Contains(state.Response!.Errors, x => x.Message.Contains(exception.Message));
    }

    [Fact]
    public async Task Handle_Should_Return_Sucess_Result()
    {
        // Arrange
        var command = new TestCommand(() => { });

        IMediator mediator = GetMediator();

        // Act
        Result result = await mediator.Send(command);

        // Assert
        Assert.True(result.IsSuccess);
    }

    public static TheoryData<Guid?> Handle_Should_Return_Failed_Result_Data =>
        new()
        {
            null,
            Guid.Empty,
            Guid.NewGuid(),
        };

    [Theory]
    [MemberData(nameof(Handle_Should_Return_Failed_Result_Data))]
    public async Task Handle_Should_Return_Failed_Result(Guid? id)
    {
        // Arrange
        var command = new TestCommand(() => EntityNotFoundException.ThrowIfNullOrDeleted<BaseAuditableEntity>(null, id));

        IMediator mediator = GetMediator();

        // Act
        Result result = await mediator.Send(command);

        // Assert
        Assert.True(result.IsFailed);

        if (id.HasValue)
        {
            Assert.Contains(result.Errors, x => x.Message.Contains(id.Value.ToString()));
        }
    }

    // TODO: Move this to an Integration Test suite?
    public static IMediator GetMediator()
    {
        IServiceProvider serviceProvider = new ServiceCollection()
            .AddScoped<IRequestExceptionHandler<TestCommand, Result, EntityNotFoundException>, EntityNotFoundExceptionHandler>()
            .AddMediatR(config => config
                .RegisterServicesFromAssemblyContaining<TestCommandHandler>())
            .BuildServiceProvider();

        return serviceProvider.GetRequiredService<IMediator>();
    }
}
