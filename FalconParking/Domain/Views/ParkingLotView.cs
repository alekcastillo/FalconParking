using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FalconParking.Domain.Views
{
    public class ParkingLotView
	{
        #region Atributos

        [Key]
        public int AggregateId { get; private set; }
        public string Code { get; private set; }
        public int TotalSlotsCount { get; private set; }
        public int AvailableSlotsCount { get; private set; }
        public int Status { get; private set; }
        public List<ParkingSlotView> Slots { get; private set; }

        #endregion

        public ParkingLotView(int aggregateId, string code, int totalSlotsCount, int availableSlotsCount, int status)
        {
            AggregateId = aggregateId;
            Code = code;
            TotalSlotsCount = totalSlotsCount;
            AvailableSlotsCount = availableSlotsCount;
            Status = status;
            Slots = new List<ParkingSlotView>();
        }
    }
}
