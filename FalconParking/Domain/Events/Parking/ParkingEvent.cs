using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    class ParkingEvent
    {
        public int ParkingLotId { get; private set; }

        public ParkingEvent(
            int parkingLotId)
        {
            ParkingLotId = parkingLotId;
        }
    }
}
