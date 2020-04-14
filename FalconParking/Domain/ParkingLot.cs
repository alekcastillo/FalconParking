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
        public int TotalSlotsCount { get; }
        public int AvailableSlotsCount { get; private set; }
        public ParkingLotStatus Status { get; private set; }
        public bool isOpen { get { return Status == ParkingLotStatus.Open; } }

        #endregion

        #region Constructor

        private ParkingLot(
            int aggregateId
            ,string code
            ,int totalSlotsCount
            ,ParkingLotStatus status) : base(aggregateId)
        {
            Code = code;
            TotalSlotsCount = totalSlotsCount;
            AvailableSlotsCount = totalSlotsCount;
            Status = status;
        }

        #endregion

        #region Metodos publicos

        public static ParkingLot New(
            int aggregateId
            ,string code
            ,int totalSlotsCount)
        {
            if (totalSlotsCount < 1)
                throw new ArgumentException($"No se puede crear un parqueo con menos de un campo!");

            return new ParkingLot(
                aggregateId
                ,code
                ,totalSlotsCount
                ,ParkingLotStatus.Open);
        }

        #endregion


    }
}
