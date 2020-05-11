using Application.Abstractions.Commands;
using System;

namespace Application.Commands
{
    public class OccupyParkingSlotCommand : ICommand<bool>
    {
        public Guid ParkingSlotId { get; }
        public Guid CurrentUserId { get; }
        public string CarLicensePlate { get; }
        public string UserIdentification { get; }

        public OccupyParkingSlotCommand() { }

        public OccupyParkingSlotCommand(
            Guid parkingSlotId
            ,Guid currentUserId
            ,string carLicensePlate
            ,string userIdentification)
        {
            ParkingSlotId = parkingSlotId;
            CurrentUserId = currentUserId;
            CarLicensePlate = carLicensePlate;
            UserIdentification = userIdentification;
        }
    }
}
