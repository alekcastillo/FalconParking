using FalconParking.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class Lot
    {
        public int id { get; private set; }
        public string code { get; private set; }
        public float x { get; private set; }
        public float y { get; private set; }
        public int totalSlots { get; private set; }
        public List<SlotOcuppation> ocuppiedSlots { get; private set; }
        public List<SlotReservation> reservedSlots { get; private set; }

        public void OcuppySlot()
        {
            var slotOccupation = new SlotOcuppation();

            if (this.freeSlots() < 1)
                throw new DomainException("No hay espacios disponibles en el parqueo");

            ocuppiedSlots.Add(slotOccupation);

            RaiseEvent(new SlotOcuppiedEvent);
        }

        private int freeSlots()
        {
            return totalSlots - (ocuppiedSlots.Count + reservedSlots.Count);
        }
    }
}
