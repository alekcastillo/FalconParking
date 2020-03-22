using FalconParking.Domain.Entities;
using FalconParking.Domain.Events;
using FalconParking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingLot : Aggregate
    {
        public string Code { get; private set; }
        public float X { get; private set; }
        public float Y { get; private set; }
        public int TotalSlotsCount { get; }
        public int AvailableSlotsCount { get; private set; }
        private ParkingSlot[] _slots { get; set; }

        public ParkingLot(
            int agregateId, 
            string code,
            float x,
            float y,
            int totalSlotsCount) : base(agregateId)
        {
            Code = code;
            X = x;
            Y = y;
            TotalSlotsCount = totalSlotsCount;
            AvailableSlotsCount = totalSlotsCount;
            _slots = new ParkingSlot[totalSlotsCount];

            for (int i = 0; i < totalSlotsCount; i++)
            {
                _slots[i] = new ParkingSlot(i + 1);
            }
        }

        public void OcuppySlot(int parkingSlotId, string carLicensePlate)
        {
            var slot = GetSlotById(parkingSlotId);

            if (!slot.isAvailable())
                throw new DomainException($"El espacio {parkingSlotId} del parqueo {Code} no esta disponible");

            slot.Ocuppy(carLicensePlate);
            AvailableSlotsCount--;

            RaiseEvent(new SlotOcuppiedEvent(parkingSlotId, carLicensePlate));
        }

        public void ReserveSlot(int parkingSlotId, string carLicensePlate, ParkingSlotReservationTime reservationTime)
        {
            var slot = GetSlotById(parkingSlotId);

            if (!slot.isAvailable())
                throw new DomainException($"El espacio {parkingSlotId} del parqueo {Code} no esta disponible para reservar");

            slot.Reserve(carLicensePlate, reservationTime);
            AvailableSlotsCount--;

            RaiseEvent(new SlotOcuppiedEvent(parkingSlotId, carLicensePlate));
        }

        private void FreeSlot(string carLicensePlate)
        {
            var slot = GetSlotByOcuppantCarLicensePlate(carLicensePlate);
            slot.Free();
            AvailableSlotsCount++;

            RaiseEvent(new SlotFreedEvent(slot.id, carLicensePlate));
        }

        private void OpenSlot(int parkingSlotId)
        {
            var slot = GetSlotById(parkingSlotId);
            slot.Open();
            AvailableSlotsCount++;

            //RaiseEvent(new SlotOpenedEvent(parkingSlotId));
        }

        private void CloseSlot(int parkingSlotId)
        {
            var slot = GetSlotById(parkingSlotId);
            slot.Close();
            AvailableSlotsCount--;

            //RaiseEvent(new SlotClosedEvent(parkingSlotId));
        }

        private ParkingSlot GetSlotById(int parkingSlotId)
        {
            if (parkingSlotId < 0 || AvailableSlotsCount < parkingSlotId)
                throw new DomainException($"El campo {parkingSlotId} no existe en el parqueo {Code}");

            var slotIndex = parkingSlotId - 1;

            return _slots[slotIndex];
        }

        private ParkingSlot GetSlotByOcuppantCarLicensePlate(string carLicensePlate)
        {
            foreach (var slot in _slots)
            {
                if (slot.currentOcuppant.carLicensePlate == carLicensePlate)
                    return slot;
            }

            throw new DomainException($"No se ha encontrado en cual campo estaba el automovil de placa {carLicensePlate} en el parqueo {Code}");
        }
    }
}
