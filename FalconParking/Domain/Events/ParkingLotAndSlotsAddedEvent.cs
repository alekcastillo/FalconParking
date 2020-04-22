using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingLotAndSlotsAddedEvent : ParkingEvent
    {
        public Guid[] ParkingSlotIds { get; }
        public int[] ReservableSlots { get; }

        public ParkingLotAndSlotsAddedEvent(
            Guid parkingLotId
            ,Guid[] parkingSlotIds
            ,int[] reservableSlots
            ,Guid currentUserId
        ) : base(
            parkingLotId
            ,currentUserId)
        {
            ParkingSlotIds = parkingSlotIds;
            ReservableSlots = reservableSlots;
        }
    }
}
