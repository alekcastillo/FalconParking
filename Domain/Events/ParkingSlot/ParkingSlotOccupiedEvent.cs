using System;

namespace Domain.Events
{
    public class ParkingSlotOccupiedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }
        public string OccupantLicensePlate { get; }

        public ParkingSlotOccupiedEvent(
            Guid aggregateId
            ,Guid currentUserId
            ,string occupant
         ) : base(
            aggregateId)
        {
            CurrentUserId = currentUserId;
            OccupantLicensePlate = occupant;
        }
    }
}
