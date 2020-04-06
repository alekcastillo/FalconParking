using FalconParking.Infrastructure.Abstractions.Events;

namespace FalconParking.Domain.Events
{
    public abstract class ParkingEvent : DomainEvent, IDomainEvent
    {
        public int UserId { get; }

        protected ParkingEvent(
            int parkingLotId
            ,int userId) : base(parkingLotId)
        {
            UserId = userId;
        }
    }
}
