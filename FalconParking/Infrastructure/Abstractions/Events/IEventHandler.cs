using MediatR;

namespace FalconParking.Infrastructure.Abstractions.Events
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IDomainEvent {}
}
