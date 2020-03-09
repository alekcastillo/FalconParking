using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    class SlotFreedEvent : SlotEvent
    {
        public LotClosed(
            int parkingLotId
            , string licensePlate) : base(parkingLotId, licensePlate)
        {

        }
    }
}
