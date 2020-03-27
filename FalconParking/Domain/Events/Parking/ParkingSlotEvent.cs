using FalconParking.Domain.Abstractions.Events;
using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public abstract class ParkingSlotEvent : ParkingEvent
    {
        public ParkingSlot Slot { get; }

        protected ParkingSlotEvent(
            int parkingLotId,
            ParkingSlot slot) : base(parkingLotId)
        {
            Slot = slot;
        }
    }
}
