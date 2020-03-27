using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    class ParkingLotClosed : ParkingEvent
    {
        public ParkingLotClosed(
            int parkingLotId) : base(parkingLotId)
        {

        }
    }
}
