using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    class SlotReservedEvent : SlotEvent
    {
        public LotClosed(
            int parkingLotId
            , string licensePlate) : base(parkingLotId, licensePlate)
        {

        }
    }
}
