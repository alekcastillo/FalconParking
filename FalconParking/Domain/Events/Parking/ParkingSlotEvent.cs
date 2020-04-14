using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    public class ParkingSlotEvent : ParkingEvent
    {
        public ParkingSlotOccupant Occupant { get; }

        protected ParkingSlotEvent(
            int aggregateId
            ,int userId
            , ParkingSlotOccupant occupant
        ) : base(
            aggregateId
            ,userId)
        {
            Occupant = occupant;
        }
    }
}
