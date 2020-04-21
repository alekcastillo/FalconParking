using FalconParking.Infrastructure.Abstractions.Events;
using System;

namespace FalconParking.Domain.Events
{
    public class DomainEvent : IDomainEvent
    {
        public Guid AggregateId { get; }
        public DateTimeOffset TimeCreated { get; }

        protected DomainEvent(
            Guid aggregateId)
        {
            AggregateId = aggregateId;
            TimeCreated = DateTimeOffset.UtcNow;
        }
    }
}
