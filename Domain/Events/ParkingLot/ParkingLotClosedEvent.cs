using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class ParkingLotClosedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }

        public ParkingLotClosedEvent(
            Guid aggregateId
            ,Guid currentUserId
        ) : base(
            aggregateId)
        {
            CurrentUserId = currentUserId;
        }
    }
}
