using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    class SlotEvent : ParkingEvent
    {
        public string LicensePlate { get; private set; }

        protected SlotEvent(
            int parkingLotId
            ,string licensePlate) : base(parkingLotId)
        {
            LicensePlate = licensePlate;
        }
    }
}
