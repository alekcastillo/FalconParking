using Domain.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class ParkingLotAddedEvent : DomainEvent
    {
        public Guid CurrentUserId { get; }
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
            aggregateId)
        {
            CurrentUserId = currentUserId;
            Code = code;
            TotalSlotsCount = totalSlotsCount;
            ReservableSlots = reservableSlots;
        }
    }
}
