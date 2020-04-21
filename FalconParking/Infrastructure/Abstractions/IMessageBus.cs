using FalconParking.Infrastructure.Abstractions.Queries;
using FalconParking.Infrastructure.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;
using FalconParking.Infrastructure.Abstractions.Events;
using System.Collections.Generic;

namespace FalconParking.Infrastructure.Abstractions
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
