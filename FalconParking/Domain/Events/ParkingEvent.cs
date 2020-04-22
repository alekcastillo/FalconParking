using FalconParking.Infrastructure.Abstractions.Events;
using System;

namespace FalconParking.Domain.Events
{
    public abstract class ParkingEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }

        protected ParkingEvent(
            Guid aggregateId
            ,Guid currentUserId) : base(aggregateId)
        {
            CurrentUserId = currentUserId;
        }
    }
}
