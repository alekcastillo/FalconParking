using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotFreedEvent : ParkingSlotEvent
    {
        public ParkingSlotFreedEvent(
            int parkingLotId,
            int slot) : base(parkingLotId, slot)
        {

        }
    }
}
