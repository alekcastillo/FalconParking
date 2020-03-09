using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    class SlotOcuppiedEvent : SlotEvent
    {
        public LotClosed(
            int parkingLotId
            , string licensePlate) : base(parkingLotId, licensePlate)
        {

        }
    }
}
