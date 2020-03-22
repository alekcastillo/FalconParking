using MediatR;

namespace FalconParking.Domain.Abstractions.Commands
{
    public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
    }
}
