using MediatR;

namespace FalconParking.Domain.Abstractions.Commands
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {

    }

    public interface ICommand : IRequest
    {

    }
}
