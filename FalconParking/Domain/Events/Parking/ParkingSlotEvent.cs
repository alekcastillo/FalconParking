using FalconParking.Domain.Abstractions.Events;
using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public abstract class ParkingSlotEvent : ParkingEvent
    {
        public int ParkingSlotId { get; }

        protected ParkingSlotEvent(
            int parkingLotId,
            int parkingSlotId) : base(parkingLotId)
        {
            ParkingSlotId = parkingSlotId;
        }
    }
}
