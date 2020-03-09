using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class SlotReservedEvent : SlotEvent
    {
        public SlotReservedEvent(
            int parkingLotId
            , string licensePlate) : base(parkingLotId, licensePlate)
        {

        }
    }
}
