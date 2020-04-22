using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingLotOpenedEvent : ParkingEvent
    {
        public ParkingLotOpenedEvent(
            Guid aggregateId
            ,Guid currentUserId
        ) : base(
            aggregateId
            ,currentUserId)
        {}
    }
}
