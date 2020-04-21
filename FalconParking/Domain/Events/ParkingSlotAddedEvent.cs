using FalconParking.Domain.Entities;
using FalconParking.Infrastructure.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FalconParking.Domain.Events
{
    public class ParkingSlotAddedEvent : ParkingSlotEvent
    {
        public Guid ParkingLotId { get; set; }
        public int SlotNumber { get; set; }
        public Boolean IsReservable { get; private set; }

        public ParkingSlotAddedEvent(
            Guid aggregateId
            ,Guid currentUserId
            ,Guid parkingLotId
            ,int slotNumber
            ,Boolean isReservable
         ) : base(
            aggregateId
            ,currentUserId)
        {
            ParkingLotId = parkingLotId;
            SlotNumber = slotNumber;
            IsReservable = isReservable;
        }
    }
}
