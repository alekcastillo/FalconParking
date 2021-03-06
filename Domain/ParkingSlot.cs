﻿using Domain.Entities;
using Domain.Events;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ParkingSlot : Aggregate
    {
        #region Atributos

        public Guid ParkingLotId { get; private set; }
        public int SlotNumber { get; private set; }
        public ParkingSlotStatus Status { get; private set; }
        public bool IsReservable { get; private set; }
        public string OccupantLicensePlate { get; private set; }
        public bool IsAvailable { get { return Status == ParkingSlotStatus.Available; } }

        #endregion

        public ParkingSlot(
            Guid aggregateId) : base(aggregateId)
        {
            OccupantLicensePlate = null;
            Status = ParkingSlotStatus.Available;
        }

        #region Metodos Publicos

        public static ParkingSlot New(
            Guid parkingLotId
            ,int slotNumber
            ,bool isReservable)
        {
            var slot = new ParkingSlot(Guid.NewGuid());

            slot.RaiseEvent(new ParkingSlotAddedEvent(
                slot.AggregateId
                ,DomainHelpers.GetSystemUser()
                ,parkingLotId
                ,slotNumber
                ,isReservable));

            return slot;
        }

        public void Occupy(
            Guid currentUserId
            ,string carLicensePlate)
        {
            OccupantLicensePlate = carLicensePlate;
            Status = ParkingSlotStatus.Occuppied;

            RaiseEvent(new ParkingSlotOccupiedEvent(
                this.AggregateId
                ,currentUserId
                ,OccupantLicensePlate));
        }

        public void Free(
            Guid currentUserId
            ,string carLicensePlate)
        {
            OccupantLicensePlate = null;
            Status = ParkingSlotStatus.Available;

            RaiseEvent(new ParkingSlotFreedEvent(
                this.AggregateId
                ,currentUserId));
        }

        public void Reserve(
            Guid currentUserId
            ,int reservationTime)
        {
            Status = ParkingSlotStatus.Reserved;

            RaiseEvent(new ParkingSlotReservedEvent(
                this.AggregateId
                ,currentUserId
                ,reservationTime));
        }

        #endregion

        #region Metodos Apply

        public void Apply(ParkingSlotAddedEvent e)
        {
            ParkingLotId = e.ParkingLotId;
            SlotNumber = e.SlotNumber;
            IsReservable = e.IsReservable;
        }

        public void Apply(ParkingSlotOccupiedEvent e)
        {
            OccupantLicensePlate = e.OccupantLicensePlate;
            Status = ParkingSlotStatus.Occuppied;
        }

        public void Apply(ParkingSlotFreedEvent e)
        {
            OccupantLicensePlate = null;
            Status = ParkingSlotStatus.Available;
        }

        public void Apply(ParkingSlotReservedEvent e)
        {
            Status = ParkingSlotStatus.Reserved;
        }

        #endregion
    }
}
