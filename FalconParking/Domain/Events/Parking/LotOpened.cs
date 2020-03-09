using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    class LotOpened : ParkingEvent
    {
        public LotOpened(
            int parkingLotId) : base(parkingLotId)
        {

        }
    }
}
