using System;

namespace Domain.Events
{
    public class ParkingSlotReservedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }
        public string OccupantLicensePlate { get; }
        public int ReservationTime { get; }

        public ParkingSlotReservedEvent(
            Guid aggregateId
            ,Guid currentUserId
            ,int reservationTime
         ) : base(
            aggregateId)
        {
            CurrentUserId = currentUserId;
            ReservationTime = reservationTime;
        }
    }
}
