using FalconParking.Infrastructure.Abstractions.Commands;
using System;

namespace FalconParking.Application.Commands
{
    public class CloseParkingLotCommand : ICommand<bool>
    {
        public Guid ParkingLotId { get; set; }
        public Guid CurrentUserId { get; set; }

        public CloseParkingLotCommand() { }

        public CloseParkingLotCommand(
            Guid parkingLotId
            ,Guid currentUserId)
        {
            ParkingLotId = parkingLotId;
            CurrentUserId = currentUserId;
        }
    }
}
