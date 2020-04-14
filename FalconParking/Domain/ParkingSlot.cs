using FalconParking.Domain.Entities;
using FalconParking.Domain.Events;
using FalconParking.Domain.Events.Parking;
using FalconParking.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain
{
    public class ParkingSlot : Aggregate
    {
        #region Atributos

        public int ParkingLotId { get; }
        public int SlotNumber { get; } 
        public ParkingSlotOccupant CurrentOccupant { get; private set; }
        public ParkingSlotStatus Status { get; private set; }
        public bool isAvailable { get { return Status == ParkingSlotStatus.Available; } }

        #endregion

        private ParkingSlot(
            int aggregateId
            ,int slotNumber
            ,int parkingLotId
            ,ParkingSlotStatus status) : base(aggregateId)
        {
            SlotNumber = slotNumber;
            ParkingLotId = parkingLotId;
            CurrentOccupant = null;
            Status = status;
        }

        #region Metodos Publicos

        public static ParkingSlot New(
            int aggregateId
            ,int parkingLotId
            ,int slotNumber)
        {
            return new ParkingSlot(
                aggregateId
                ,slotNumber
                ,parkingLotId
                ,ParkingSlotStatus.Available);
        }

        #endregion

        public void Occupy(int userId, string carLicensePlate)
        {
            var newOccupant = new ParkingSlotOccupant(carLicensePlate);
            CurrentOccupant = newOccupant;
            Status = ParkingSlotStatus.Occuppied;

            RaiseEvent(new ParkingSlotOccupiedEvent(
                this.AggregateId
                ,userId
                ,CurrentOccupant));
        }


        #region Metodos Apply

        public void Apply(ParkingSlotOccupiedEvent parkingEvent)
        {
            CurrentOccupant = parkingEvent.Occupant;
            Status = ParkingSlotStatus.Occuppied;
        }

        #endregion
    }
}
