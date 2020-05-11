using System;

namespace Domain.Events
{
    public class ParkingSlotFreedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }
        public string OccupantLicensePlate { get; }

        public ParkingSlotFreedEvent(
            Guid aggregateId
            ,Guid currentUserId
         ) : base(
            aggregateId)
        {
            CurrentUserId = currentUserId;
        }
    }
}
