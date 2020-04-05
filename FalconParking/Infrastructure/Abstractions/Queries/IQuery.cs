using MediatR;

namespace FalconParking.Infrastructure.Abstractions.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse> {}
}
