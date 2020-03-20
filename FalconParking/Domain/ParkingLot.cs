using FalconParking.Domain.Entities;
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
        public int totalSlotsCount { get; private set; }
        public int availableSlotsCount { get; private set; }
        public ParkingSlot[] slots { get; private set; }

        public ParkingLot(
            int Id,
            string Code,
            float X,
            float Y,
            int TotalSlotsCount)
        {
            id = Id;
            code = Code;
            x = X;
            y = Y;
            totalSlotsCount = TotalSlotsCount;
            availableSlotsCount = totalSlotsCount;
            slots = new ParkingSlot[totalSlotsCount];

            for (int i = 0; i < totalSlotsCount; i++)
            {
                slots[i] = new ParkingSlot(i + 1);
            }
        }

        public void OcuppySlot(string carLicensePlate, int parkingSlotId)
        {
            if (this.freeSlots() < 1)
                throw new DomainException("No hay espacios disponibles en el parqueo");

            var slotOccupation = new ParkingSlotOcuppant(carLicensePlate);



            ocuppiedSlots.Add(slotOccupation);

            RaiseEvent(new SlotOcuppiedEvent(1, "aa"));
        }

        private int freeSlots()
        {
            return totalSlots - (ocuppiedSlots.Count + reservedSlots.Count);
        }
        private ParkingSlot GetSlotById(int parkingSlotId)
        {
            if (slots.Length < parkingSlotId)
                throw new DomainException($"El campo {parkingSlotId} no existe en el parqueo {code}");

            var slotIndex = parkingSlotId - 1;

            return slots[slotIndex];
        }
    }
}
