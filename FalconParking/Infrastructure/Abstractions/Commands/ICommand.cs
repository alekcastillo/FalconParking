using MediatR;

namespace FalconParking.Infrastructure.Abstractions.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse> {}

    public interface ICommand : IRequest {}
}
