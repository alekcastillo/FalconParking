using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    class SlotOcuppiedEvent : SlotEvent
    {
        public SlotOcuppiedEvent(
            int parkingLotId
            , string licensePlate) : base(parkingLotId, licensePlate)
        {

        }
    }
}
