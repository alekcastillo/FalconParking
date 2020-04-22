using FalconParking.Infrastructure.Abstractions.Commands;
using System;

namespace FalconParking.Application.Commands
{
    public class OpenParkingLotCommand : ICommand<bool>
    {
        public Guid ParkingLotId { get; set; }
        public Guid CurrentUserId { get; set; }

        public OpenParkingLotCommand() { }

        public OpenParkingLotCommand(
            Guid parkingLotId
            ,Guid currentUserId)
        {
            ParkingLotId = parkingLotId;
            CurrentUserId = currentUserId;
        }
    }
}
