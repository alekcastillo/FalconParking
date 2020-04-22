using FalconParking.Infrastructure.Abstractions;
using FalconParking.Infrastructure.Abstractions.Commands;
using FalconParking.Infrastructure.Abstractions.Events;
using FalconParking.Infrastructure.Abstractions.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IMediator _bus;

        public MessageBus(
            IMediator bus)
        {
            _bus = bus;
        }

        public async Task<TResponse> SendAsync<TResponse>(
            ICommand<TResponse> request,
            CancellationToken cancellationToken = default)
        {
            return await _bus.Send(request, cancellationToken);
        }

        public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken = default)
        {
            return await _bus.Send(request, cancellationToken);
        }

        public async Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default)
        {
            await _bus.Publish(domainEvent, cancellationToken);
        }

        public async Task PublishRangeAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default)
        {
            foreach (var domainEvent in domainEvents.OrderBy(x => x.TimeCreated))
            {
                await _bus.Publish(domainEvent, cancellationToken);
            }
        }
    }
}
