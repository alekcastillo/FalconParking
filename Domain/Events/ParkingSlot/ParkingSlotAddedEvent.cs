using System;

namespace Domain.Events
{
    public class ParkingSlotAddedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }
        public Guid ParkingLotId { get; }
        public int SlotNumber { get; }
        public Boolean IsReservable { get; }

        public ParkingSlotAddedEvent(
            Guid aggregateId
            ,Guid currentUserId
            ,Guid parkingLotId
            ,int slotNumber
            ,Boolean isReservable
         ) : base(
            aggregateId)
        {
            ParkingLotId = parkingLotId;
            CurrentUserId = currentUserId;
            SlotNumber = slotNumber;
            IsReservable = isReservable;
        }
    }
}
