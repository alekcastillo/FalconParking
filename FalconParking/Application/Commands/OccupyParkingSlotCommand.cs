using FalconParking.Infrastructure.Abstractions.Commands;

namespace FalconParking.Application.Commands
{
    public class OccupyParkingSlotCommand : ICommand<string>
    {
        public int AggregateId { get; }
        public int ParkingSlotId { get; }
        public string CarLicensePlate { get; }
        public string UserIdentification { get; }

        public OccupyParkingSlotCommand(
            int aggregateId
            ,int parkingSlotId
            ,string carLicensePlate
            ,string userIdentification)
        {
            AggregateId = aggregateId;
            ParkingSlotId = parkingSlotId;
            CarLicensePlate = carLicensePlate;
            UserIdentification = userIdentification;
        }
    }
}
