using MediatR;
using System;

namespace FalconParking.Infrastructure.Abstractions.Events
{
    public interface IDomainEvent : INotification
    {
        Guid AggregateId { get; }
        DateTimeOffset TimeCreated { get; }
    }
}
