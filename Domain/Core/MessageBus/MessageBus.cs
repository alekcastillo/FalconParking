using Domain.Abstractions.Events;
using Application.Abstractions.Events;
using Application.Abstractions.Queries;
using Application.Abstractions.Commands;
using Application.Abstractions;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.MessageBus
{
    public class MessageBus : IMessageBus
    {
        private readonly IMediator _bus;

        public MessageBus(
            IMediator bus)
        {
            _bus = bus;
        }

        public async Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> c, CancellationToken cancellationToken = default)
        {
            return await _bus.Send(c, cancellationToken);
        }

        public async Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> q, CancellationToken cancellationToken = default)
        {
            return await _bus.Send(q, cancellationToken);
        }

        public async Task PublishAsync(IDomainEvent e, CancellationToken cancellationToken = default)
        {
            await _bus.Publish(e, cancellationToken);
        }

        public async Task PublishRangeAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default)
        {
            foreach (var e in events.OrderBy(x => x.TimeCreated))
            {
                await this.PublishAsync(e, cancellationToken);
            }
        }
    }
}
