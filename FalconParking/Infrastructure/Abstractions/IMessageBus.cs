using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.Abstractions
{
    interface IMessageBus
    {
        //Task<TResponse> SendAsync<TResponse>(Commands.ICommand<TResponse> request, CancellationToken token = default);
        //Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken token = default);
        //Task PublishAsync<TEvent>(TEvent eventMessage, CancellationToken token = new CancellationToken()) where TEvent : IDomainEvent;
        //Task DispatchEventsAsync(IEnumerable<IDomainEvent> @event, CancellationToken token = default);
    }
}
