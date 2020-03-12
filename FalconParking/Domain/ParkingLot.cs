using FalconParking.Domain.Events;
using FalconParking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingLot
    {
        public int id { get; private set; }
        public string code { get; private set; }
        public float x { get; private set; }
        public float y { get; private set; }
        public int totalSlots { get; private set; }
        private List<SlotOcuppation> ocuppiedSlots { get; }
        private List<SlotReservation> reservedSlots { get; }
        public int ocuppiedSlotsCount { get { return this.ocuppiedSlots.Count; } };

        public void OcuppySlot()
        {
            var slotOccupation = new SlotOcuppation();

            if (this.freeSlots() < 1)
                throw new DomainException("No hay espacios disponibles en el parqueo");

            ocuppiedSlots.Add(slotOccupation);

            RaiseEvent(new SlotOcuppiedEvent(1, "aa"));
        }

        private int freeSlots()
        {
            return totalSlots - (ocuppiedSlots.Count + reservedSlots.Count);
        }
    }
}
