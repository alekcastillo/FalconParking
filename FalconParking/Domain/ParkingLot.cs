using FalconParking.Domain.Attributes;
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
        #region Atributos

        public string Code { get; private set; }
        public float X { get; private set; }
        public float Y { get; private set; }
        public int TotalSlotsCount { get; }
        public int AvailableSlotsCount { get; private set; }
        public ParkingLotStatus Status { get; private set; }
        private ParkingSlot[] _slots { get; set; }

        #endregion

        #region Constructor

        private ParkingLot(
            int aggregateId
            ,string code
            ,float x
            ,float y
            ,int totalSlotsCount
            ,ParkingLotStatus status
            ,ParkingSlot[] slots) : base(aggregateId)
        {
            Code = code;
            X = x;
            Y = y;
            TotalSlotsCount = totalSlotsCount;
            AvailableSlotsCount = totalSlotsCount;
            Status = status;
            _slots = slots;
        }

        #endregion

        #region Metodos privados

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
                if (slot.CurrentOcuppant.CarLicensePlate == carLicensePlate)
                    return slot;
            }

            throw new DomainException($"No se ha encontrado en cual campo estaba el automovil de placa {carLicensePlate} en el parqueo {Code}");
        }

        #endregion

        #region Metodos publicos

        public static ParkingLot New(
            int aggregateId,
            string code,
            float x,
            float y,
            int totalSlotsCount)
        {
            if (totalSlotsCount > 1)
                throw new ArgumentException($"No se puede crear un parqueo con menos de un campo!");

            var slots = new ParkingSlot[totalSlotsCount];

            for (int i = 0; i < totalSlotsCount; i++)
            {
                slots[i] = new ParkingSlot(i + 1);
            }

            return new ParkingLot(
                aggregateId
                ,code
                ,x
                ,y
                ,totalSlotsCount
                ,ParkingLotStatus.Open
                ,slots);
        }

        public void Open()
        {
            Status = ParkingLotStatus.Open;

            //RaiseEvent(new ParkingLotOpenedEvent(AggregateId));
        }

        public void OcuppySlot(int parkingSlotId, string carLicensePlate)
        {
            var slot = GetSlotById(parkingSlotId);

            if (!slot.isAvailable())
                throw new DomainException($"El espacio {parkingSlotId} del parqueo {Code} no esta disponible");

            slot.Ocuppy(carLicensePlate);
            AvailableSlotsCount--;

            RaiseEvent(new ParkingSlotOcuppiedEvent(AggregateId, slot));
        }

        public void ReserveSlot(int parkingSlotId, string carLicensePlate, ParkingSlotReservationTime reservationTime)
        {
            var slot = GetSlotById(parkingSlotId);

            if (!slot.isAvailable())
                throw new DomainException($"El espacio {parkingSlotId} del parqueo {Code} no esta disponible para reservar");

            slot.Reserve(carLicensePlate, reservationTime);
            AvailableSlotsCount--;

            RaiseEvent(new ParkingSlotReservedEvent(AggregateId, slot));
        }

        private void FreeSlot(string carLicensePlate)
        {
            var slot = GetSlotByOcuppantCarLicensePlate(carLicensePlate);
            slot.Free();
            AvailableSlotsCount++;

            RaiseEvent(new ParkingSlotFreedEvent(AggregateId, slot));
        }

        private void OpenSlot(int parkingSlotId)
        {
            var slot = GetSlotById(parkingSlotId);
            slot.Open();
            AvailableSlotsCount++;

            RaiseEvent(new ParkingSlotOpenedEvent(AggregateId, slot));
        }

        private void CloseSlot(int parkingSlotId)
        {
            var slot = GetSlotById(parkingSlotId);
            slot.Close();
            AvailableSlotsCount--;

            RaiseEvent(new ParkingSlotClosedEvent(AggregateId, slot));
        }

        #endregion

        #region Metodos Apply

        public void Apply(ParkingSlotOcuppiedEvent parkingEvent) {
            Apply(parkingEvent.Slot);
        }

        public void Apply(ParkingSlotReservedEvent parkingEvent)
        {
            Apply(parkingEvent.Slot);
        }

        public void Apply(ParkingSlotFreedEvent parkingEvent)
        {
            Apply(parkingEvent.Slot);
        }

        public void Apply(ParkingSlotOpenedEvent parkingEvent)
        {
            Apply(parkingEvent.Slot);
        }

        public void Apply(ParkingSlotClosedEvent parkingEvent)
        {
            Apply(parkingEvent.Slot);
        }

        public void Apply(ParkingSlot parkingSlot)
        {
            var parkingSlotId = parkingSlot.Id;

            if (parkingSlotId > -1 && AvailableSlotsCount >= parkingSlotId)
                _slots[parkingSlot.Id - 1] = parkingSlot;
        }

        #endregion
    }
}
