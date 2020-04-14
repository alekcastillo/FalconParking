using FalconParking.Infrastructure.Abstractions.Commands;

namespace FalconParking.Application.Commands
{
    public class OccupyParkingSlotCommand : ICommand<string>
    {
        public int AggregateId { get; }
        public int UserId { get; }
        public int ParkingSlotId { get; }
        public string CarLicensePlate { get; }
        public string UserIdentification { get; }

        public OccupyParkingSlotCommand(
            int aggregateId
            ,int userId
            ,int parkingSlotId
            ,string carLicensePlate
            ,string userIdentification)
        {
            AggregateId = aggregateId;
            UserId = userId;
            ParkingSlotId = parkingSlotId;
            CarLicensePlate = carLicensePlate;
            UserIdentification = userIdentification;
        }
    }
}
