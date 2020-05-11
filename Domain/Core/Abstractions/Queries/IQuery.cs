using MediatR;

namespace Application.Abstractions.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse> {}
}
