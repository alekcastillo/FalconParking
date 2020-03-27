using FalconParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Collections
{
    class ParkingSlotCollection
    {
        private ParkingSlot[] slots { get; set; }
        public void Occupy(int parkingSlotId)
        {
            var slotIndex = parkingSlotId - 1;
            var slot = slots[slotIndex];
        }
    }
}
