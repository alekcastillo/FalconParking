using FalconParking.Domain.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class DomainEvent : IDomainEvent
    {
        int AggregateId;

        public DomainEvent(int aggregateId)
        {
        }
    }
}
