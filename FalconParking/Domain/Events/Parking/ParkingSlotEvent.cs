

namespace FalconParking.Domain.Events
{
    public abstract class ParkingSlotEvent : ParkingEvent
    {
        public int ParkingSlotId { get; }

        protected ParkingSlotEvent(
            int parkingLotId
            ,int userId
            ,int parkingSlotId
        ) : base(
            parkingLotId
            ,userId)
        {
            ParkingSlotId = parkingSlotId;
        }
    }
}
