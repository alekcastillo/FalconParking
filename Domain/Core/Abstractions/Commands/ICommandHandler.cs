using MediatR;

namespace Application.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
        where TCommand : ICommand<TResult> {}
}
