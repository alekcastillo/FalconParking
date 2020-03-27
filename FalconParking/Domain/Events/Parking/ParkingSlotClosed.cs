using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotClosedEvent : ParkingSlotEvent
    {
        public ParkingSlotClosedEvent(
            int parkingLotId,
            ParkingSlot slot) : base(parkingLotId, slot)
        {

        }
    }
}
