using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingLotClosedEvent : ParkingEvent
    {
        public ParkingLotClosedEvent(
            Guid aggregateId
            ,Guid currentUserId
        ) : base(
            aggregateId
            ,currentUserId)
        {}
    }
}
