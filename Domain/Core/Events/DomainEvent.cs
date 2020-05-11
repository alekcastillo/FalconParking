using Domain.Abstractions.Events;
using System;

namespace Domain.Events
{
    public abstract class DomainEvent : IDomainEvent
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
