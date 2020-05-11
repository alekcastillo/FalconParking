using Application.Abstractions.Queries;
using Application.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Abstractions.Events;

namespace Application.Abstractions
{
    public interface IMessageBus
    {
        Task<TResponse> SendAsync<TResponse>(
            ICommand<TResponse> request
            ,CancellationToken cancellationToken = default);

        Task<TResponse> SendAsync<TResponse>(
            IQuery<TResponse> request
            ,CancellationToken cancellationToken = default);

        Task PublishAsync(
            IDomainEvent domainEvent
            ,CancellationToken cancellationToken = default);

        Task PublishRangeAsync(
            IEnumerable<IDomainEvent> domainEvents
            ,CancellationToken cancellationToken = default);
    }
}
