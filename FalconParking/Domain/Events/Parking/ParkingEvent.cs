using FalconParking.Infrastructure.Abstractions.Events;

namespace FalconParking.Domain.Events
{
    public abstract class ParkingEvent : DomainEvent, IDomainEvent
    {
        public int UserId { get; }

        protected ParkingEvent(
            int aggregateId
            ,int userId) : base(aggregateId)
        {
            UserId = userId;
        }
    }
}
