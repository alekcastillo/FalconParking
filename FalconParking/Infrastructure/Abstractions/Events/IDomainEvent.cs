using MediatR;
using System;

namespace FalconParking.Infrastructure.Abstractions.Events
{
    public interface IDomainEvent : INotification
    {
        int AggregateId { get; }
        DateTimeOffset TimeCreated { get; }
    }
}
