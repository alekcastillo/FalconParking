using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotOcuppiedEvent : ParkingSlotEvent
    {
        public ParkingSlotOcuppiedEvent(
            int parkingLotId,
            ParkingSlot slot) : base(parkingLotId, slot)
        {

        }
    }
}
