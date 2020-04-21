using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingLotAddedEvent : ParkingEvent
    {
        public string Code { get; set; }
        public int TotalSlotsCount { get; }
        public int[] ReservableSlots { get; set; }

        public ParkingLotAddedEvent(
            Guid aggregateId
            ,Guid currentUserId
            ,string code
            ,int totalSlotsCount
            ,int[] reservableSlots
        ) : base(
            aggregateId
            ,currentUserId)
        {
            Code = code;
            TotalSlotsCount = totalSlotsCount;
            ReservableSlots = reservableSlots;
        }
    }
}
