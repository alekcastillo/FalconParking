using MediatR;

namespace FalconParking.Infrastructure.Abstractions.Queries
{
    interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult> {}
}
