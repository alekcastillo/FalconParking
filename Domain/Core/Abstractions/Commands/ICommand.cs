using MediatR;

namespace Application.Abstractions.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse> {}

    public interface ICommand :
        IRequest {}
}
