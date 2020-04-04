using FalconParking.Domain.Abstractions.Events;
using FalconParking.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class DomainEvent : IDomainEvent
    {
        public int AggregateId { get; }

        public DomainEvent(int aggregateId)
        {
        }
    }
}
