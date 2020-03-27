using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotOpenedEvent : ParkingSlotEvent
    {
        public ParkingSlotOpenedEvent(
            int parkingLotId,
            ParkingSlot slot) : base(parkingLotId, slot)
        {

        }
    }
}
