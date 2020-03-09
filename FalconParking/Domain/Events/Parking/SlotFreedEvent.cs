using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class SlotFreedEvent : SlotEvent
    {
        public SlotFreedEvent(
            int parkingLotId
            , string licensePlate) : base(parkingLotId, licensePlate)
        {

        }
    }
}
