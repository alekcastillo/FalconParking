using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events.Parking
{
    class LotClosed : ParkingEvent
    {
        public LotClosed(
            int parkingLotId) : base(parkingLotId)
        {

        }
    }
}
