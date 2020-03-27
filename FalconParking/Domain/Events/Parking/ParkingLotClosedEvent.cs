using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    class ParkingLotClosedEvent : ParkingEvent
    {
        public ParkingLotClosedEvent(
            int parkingLotId) : base(parkingLotId)
        {

        }
    }
}
