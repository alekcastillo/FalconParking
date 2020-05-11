using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class ParkingLotOpenedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }

        public ParkingLotOpenedEvent(
            Guid aggregateId
            ,Guid currentUserId
        ) : base(
            aggregateId)
        {
            CurrentUserId = currentUserId;
        }
    }
}
