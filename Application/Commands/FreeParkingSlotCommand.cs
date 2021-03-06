﻿using Application.Abstractions.Commands;
using System;

namespace Application.Commands
{
    public class FreeParkingSlotCommand : ICommand<bool>
    {
        public Guid ParkingSlotId { get; }
        public Guid CurrentUserId { get; }
        public string CarLicensePlate { get; }

        public FreeParkingSlotCommand() { }

        public FreeParkingSlotCommand(
            Guid parkingSlotId
            ,Guid currentUserId
            ,string carLicensePlate)
        {
            ParkingSlotId = parkingSlotId;
            CurrentUserId = currentUserId;
            CarLicensePlate = carLicensePlate;
        }
    }
}
