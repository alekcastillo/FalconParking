using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    public class ParkingSlotOccupiedEvent : ParkingSlotEvent
    {
        public ParkingSlotOccupiedEvent(
            int aggregateId
            ,int userId
            ,ParkingSlotOccupant occupant
         ) : base(
            aggregateId
            ,userId
            ,occupant)
        {}
    }
}
