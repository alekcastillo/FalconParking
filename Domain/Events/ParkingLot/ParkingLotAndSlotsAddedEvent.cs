using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class ParkingLotAndSlotsAddedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }
        public Guid[] ParkingSlotIds { get; }
        public int[] ReservableSlots { get; }

        public ParkingLotAndSlotsAddedEvent(
            Guid parkingLotId
            ,Guid currentUserId
            ,Guid[] parkingSlotIds
            ,int[] reservableSlots
        ) : base(
            parkingLotId)
        {
            CurrentUserId = currentUserId;
            ParkingSlotIds = parkingSlotIds;
            ReservableSlots = reservableSlots;
        }
    }
}
