using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    class ParkingLotOpenedEvent : ParkingEvent
    {
        public ParkingLotOpenedEvent(
            int parkingLotId) : base(parkingLotId)
        {

        }
    }
}
