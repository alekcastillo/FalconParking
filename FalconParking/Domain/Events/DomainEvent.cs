using FalconParking.Infrastructure.Abstractions.Events;
using System;

namespace FalconParking.Domain.Events
{
    public class DomainEvent : IDomainEvent
    {
        public int AggregateId { get; }
        public DateTimeOffset CreateTime { get; }

        protected DomainEvent(
            int aggregateId)
        {
            AggregateId = aggregateId;
            CreateTime = DateTimeOffset.UtcNow;
        }
    }
}
