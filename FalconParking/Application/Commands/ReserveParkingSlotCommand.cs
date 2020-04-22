using FalconParking.Infrastructure.Abstractions.Commands;
using System;

namespace FalconParking.Application.Commands
{
    public class ReserveParkingSlotCommand : ICommand<bool>
    {
        public Guid ParkingSlotId { get; set; }
        public Guid CurrentUserId { get; set; }
        public int ReservationTime { get; set; }

        public ReserveParkingSlotCommand() { }

        public ReserveParkingSlotCommand(
            Guid parkingSlotId
            ,Guid currentUserId
            ,int reservationTime)
        {
            ParkingSlotId = parkingSlotId;
            CurrentUserId = currentUserId;
            ReservationTime = reservationTime;
        }
    }
}
