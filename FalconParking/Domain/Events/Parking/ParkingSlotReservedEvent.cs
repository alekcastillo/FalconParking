using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotReservedEvent : ParkingSlotEvent
    {
        public ParkingSlotReservedEvent(
            int parkingLotId,
            int slot) : base(parkingLotId, slot)
        {

        }
    }
}
