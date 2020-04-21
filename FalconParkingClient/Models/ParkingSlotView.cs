using FalconParkingClient.Attributes;
using System;

namespace FalconParkingClient.Models
{
    public class ParkingSlotView
    {
        #region Atributos

        public Guid AggregateId { get; set; }
        public Guid ParkingLotId { get; set; }
        public ParkingLotView ParkingLot { get; set; }
        public int SlotNumber { get; set;  }
        public int Status { get; set; }
        public bool IsReservable { get; set; }
        public string CurrentOccupantLicensePlate { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsAvailable { get { return Status == (int)ParkingSlotStatus.Disponible; } }
        public string IsReservableText { get { return IsReservable ? "Si" : "No"; } }
        public string StatusText { get { return ((ParkingSlotStatus)Status).ToString(); } }

        #endregion
        public ParkingSlotView() { }

        public ParkingSlotView(
            Guid aggregateId
            ,Guid parkingLotId
            ,ParkingLotView parkingLot
            ,int slotNumber
            ,int status
            ,bool isReservable
            ,string currentOccupantLicensePlate
            ,DateTimeOffset updatedTime
            ,Guid updatedBy)
        {
            AggregateId = aggregateId;
            ParkingLotId = parkingLotId;
            ParkingLot = parkingLot;
            SlotNumber = slotNumber;
            Status = status;
            IsReservable = isReservable;
            CurrentOccupantLicensePlate = currentOccupantLicensePlate;
            UpdatedTime = updatedTime;
            UpdatedBy = updatedBy;
        }
    }
}
