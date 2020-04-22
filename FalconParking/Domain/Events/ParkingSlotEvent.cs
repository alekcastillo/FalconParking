using FalconParking.Infrastructure.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotEvent : ParkingEvent
    {
        protected ParkingSlotEvent(
            Guid aggregateId
            ,Guid currentUserId
        ) : base(
            aggregateId
            ,currentUserId)
        {}
    }
}
