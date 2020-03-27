using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    class ParkingLotOpened : ParkingEvent
    {
        public ParkingLotOpened(
            int parkingLotId) : base(parkingLotId)
        {

        }
    }
}
