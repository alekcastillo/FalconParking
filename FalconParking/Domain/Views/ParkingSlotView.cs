using System;

namespace FalconParking.Domain.Views
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
