using FalconParking.Domain.Entities;
using FalconParking.Infrastructure.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotFreedEvent : ParkingSlotEvent
    {

        public ParkingSlotFreedEvent(
            Guid aggregateId
            ,Guid currentUserId
         ) : base(
            aggregateId
            ,currentUserId)
        { }
    }
}
