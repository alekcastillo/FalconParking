using System;
using System.Collections.Generic;

namespace FalconParkingClient.Views
{
    public class ParkingLotView
    {
        #region Atributos

        public Guid AggregateId { get; set; }
        public string Code { get; set; }
        public int TotalSlotsCount { get; set; }
        public int AvailableSlotsCount { get; set; }
        public int Status { get; set; }
        public ICollection<ParkingSlotView> Slots { get; set; }
        public DateTimeOffset UpdatedTime { get; set; }
        public Guid UpdatedBy { get; set; }

        #endregion
        public ParkingLotView() { }

        public ParkingLotView(
            Guid aggregateId
            ,string code
            ,int totalSlotsCount
            ,int availableSlotsCount
            ,int status
            ,ICollection<ParkingSlotView> slots
            ,DateTimeOffset updatedTime
            ,Guid updatedBy)
        {
            AggregateId = aggregateId;
            Code = code;
            TotalSlotsCount = totalSlotsCount;
            AvailableSlotsCount = availableSlotsCount;
            Status = status;
            Slots = slots;
            UpdatedTime = updatedTime;
            UpdatedBy = updatedBy;
        }
    }
}
