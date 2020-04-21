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
        public int TotalSlotsCount { get; private set; }
        public int AvailableSlotsCount { get; private set; }
        public ParkingLotStatus Status { get; private set; }
        public bool isOpen { get { return Status == ParkingLotStatus.Open; } }

        #endregion

        #region Constructor

        public ParkingLot(
            Guid aggregateId) : base(aggregateId)
        {
            Status = ParkingLotStatus.Closed;
        }

        #endregion

        #region Metodos publicos

        public static ParkingLot New(
            string code
            ,int totalSlotsCount
            ,int[] reservableSlots)
        {
            if (code == "")
                throw new ArgumentException($"No se puede crear un parqueo sin codigo!");

            if (totalSlotsCount < 1)
                throw new ArgumentException($"No se puede crear un parqueo con menos de un campo!");

            var parkingLot = new ParkingLot(Guid.NewGuid());

            parkingLot.RaiseEvent(new ParkingLotAddedEvent(
                parkingLot.AggregateId
                ,DomainHelpers.GetSystemUser()
                ,code
                ,totalSlotsCount
                ,reservableSlots));

            return parkingLot;
        }

        public void Open(Guid currentUserId)
        {
            Status = ParkingLotStatus.Open;

            RaiseEvent(new ParkingLotOpenedEvent(
                AggregateId
                ,currentUserId));
        }

        public void Close(Guid currentUserId)
        {
            Status = ParkingLotStatus.Closed;

            RaiseEvent(new ParkingLotClosedEvent(
                AggregateId
                ,currentUserId));
        }

        #endregion

        #region Metodos Apply

        public void Apply(ParkingLotAddedEvent e)
        {
            Code = e.Code;
            TotalSlotsCount = e.TotalSlotsCount;
            AvailableSlotsCount = e.TotalSlotsCount;
        }

        public void Apply(ParkingLotOpenedEvent parkingEvent)
        {
            Status = ParkingLotStatus.Open;
        }

        public void Apply(ParkingLotClosedEvent parkingEvent)
        {
            Status = ParkingLotStatus.Closed;
        }

        #endregion
    }
}
